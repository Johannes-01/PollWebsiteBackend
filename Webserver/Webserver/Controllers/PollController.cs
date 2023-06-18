using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Webserver.Context;
using Webserver.DTOs;
using Webserver.Model;

namespace Webserver.Controllers
{
    public class PollController : Controller
    {
        private readonly PollDbContext context;
        private readonly ILogger<UserController> _logger;

        public PollController(PollDbContext context, ILogger<UserController> logger)
        {
            this.context = context;
            this._logger = logger;
        }

        /// <summary>
        /// Creates a Poll.
        /// </summary>
        /// <param name="data">DTO for Poll.</param>
        /// <returns>Returns a Poll with its id.</returns>
        [HttpPost("/polls/create")]
        public async Task<IActionResult> createPoll([FromBody] CreatePollDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (User.Identity.IsAuthenticated)
            {
                var startDate = data.startDate.ToUniversalTime().ToString("yyyy'-'MM'-'dd");
                var endDate = data.startDate.ToUniversalTime().ToString("yyyy'-'MM'-'dd");

                try
                {
                    var poll = context.Polls.Add(new Poll
                    {
                        UserID = data.Author,
                        Description = data.Description,
                        Title = data.Title,
                        StartDate = data.startDate.ToUniversalTime(),
                        EndDate = data.endDate.ToUniversalTime(),
                        Created = DateTime.UtcNow,
                    });

                    context.Polls.Add(poll.Entity);
                    await context.SaveChangesAsync();

                    var pollId = poll.Entity.PollID;

                    List<int> questionIds = new List<int>();

                    if(data.questions != null && data.questions.Count > 0)
                    {
                        foreach (var question in data.questions)
                        {
                            var q = context.Questions.Add(new Question
                            {
                                Description = question.Description,
                                Heading = question.Heading,
                                Index = question.Index,
                                PollID = pollId,
                                QuestionType = question.Type,
                            });

                            context.Questions.Add(q.Entity);
                            await context.SaveChangesAsync();

                            var questionId = q.Entity.QuestionID;
                            questionIds.Add(questionId);
                        }

                        // Get back both ids to write it in the QuestionsOnPoll table.
                        foreach (var questionId in questionIds)
                        {
                            var entry = context.QuestionsOnPolls.Add(new QuestionsOnPoll
                            {
                                PollId = pollId,
                                QuestionId = questionId,
                            });
                        }
                    }

                    await context.SaveChangesAsync();

                    return CreatedAtAction(nameof(createPoll), new { id = poll.Entity.PollID }, poll.Entity);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating a poll");

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a poll.: " + ex);
                }
            }
            else
            {
                return Unauthorized("You are not logged in.");
            }

        }

        /// <summary>
        /// Get own polls from userid.
        /// </summary>
        /// <param name="id">UserId.</param>
        /// <returns>Returns the polls the user created.</returns>
        [HttpGet("/user/{id}/polls")]
        public async Task<IActionResult> getUserCreatedPolls([FromRoute] int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    var polls = this.context.Polls.Where(poll => poll.UserID == id);

                    if (polls == null)
                    {
                        return NotFound("User has no Polls");
                    }
                    return Ok(polls);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching own polls");

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching own polls: " + ex);
                }
            }
            else
            {
                return Unauthorized("You are not logged in.");
            }
        }          

        // To Do: taking a poll
        [HttpPost("/polls/question/takequestion")]
        public async Task<IActionResult> answerQuestions([FromBody] AnswerDTO answer)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    // checks if the poll exits.
                    var poll = this.context.Polls.FirstOrDefault(poll => poll.PollID == answer.SurveyID);
                    if(poll == null)
                    {
                        return NotFound("No Poll with id: " + answer.SurveyID + " found.");
                    }

                    // shows if the question exits in the poll.
                    var questions = this.context.Questions.Where(questions => questions.PollID == answer.SurveyID).ToList();
                    
                    if(questions == null)
                    {
                        return NotFound("Poll has no questions.");
                    }
                    foreach (var question in questions)
                    {
                        if(question.QuestionID == answer.QuestionID)
                        {
                            var answerObject = context.Answers.Add(new Answer{
                                QuestionID = answer.QuestionID,
                                SurveyID = answer.SurveyID,
                                UserID = answer.UserID,
                                AnswerType = answer.AnswerType,
                            });
                            ////handle question type
                            //if(answerObject.Entity.AnswerType == AnswerType.Intanswer)
                            //{
                            //    //intanswer
                            //    //adjust dto to get the int/textanswer values
                            //}
                            //else
                            //{
                            //    //textanswer
                            //    var textquestion = context.Textanswer.Add(new Textanswer
                            //    {
                                    
                            //    });
                            //}
                        }
                    }
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error taking a poll");

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating taking a poll.: " + ex);
                }
            }
            else
            {
                return Unauthorized("You are not logged in.");
            }

        }

        [HttpGet("/polls/{id}")]
        public async Task<IActionResult> getPoll(int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {

                    var poll = this.context.Polls.FirstOrDefault(poll => poll.PollID == id);

                    if (poll == null)
                    {
                        return NotFound();
                    }

                    return Ok(poll);
                }
                else
                {
                    return Unauthorized("You are not logged in.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to fetch polls: " + ex);

                return StatusCode(StatusCodes.Status500InternalServerError, "Error trying to fetch polls: " + ex);
            }

        }

        [HttpGet("/polls/{id}/questions")]
        public async Task<IActionResult> getQuestionsFromPoll([FromRoute] int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var questions = this.context.Questions.Where(questions => questions.PollID == id).ToList();

                    if (questions == null)
                    {
                        return NotFound();
                    }

                    return Ok(questions);
                }
                else
                {
                    return Unauthorized("You are not logged in.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to fetch questions: " + ex);

                return StatusCode(StatusCodes.Status500InternalServerError, "Error trying to fetch questions.: " + ex);
            }
        }
    }
}
