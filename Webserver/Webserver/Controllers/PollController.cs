using Microsoft.AspNetCore.Mvc;
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
                    var poll = context.Poll.Add(new Poll
                    {
                        UserID = data.Author,
                        Description = data.Description,
                        Title = data.Title,
                        StartDate = data.startDate.ToUniversalTime(),
                        EndDate = data.endDate.ToUniversalTime(),
                        Created = DateTime.UtcNow,
                    });

                    context.Poll.Add(poll.Entity);
                    await context.SaveChangesAsync();

                    var pollId = poll.Entity.PollID;

                    List<int> questionIds = new List<int>();

                    if (data.questions != null && data.questions.Count > 0)
                    {
                        foreach (var question in data.questions)
                        {
                            var q = context.Question.Add(new Question
                            {
                                Description = question.Description,
                                Heading = question.Heading,
                                Index = question.Index,
                                PollID = pollId,
                                QuestionType = (QuestionType)question.Type,
                            });

                            context.Question.Add(q.Entity);
                            await context.SaveChangesAsync();

                            var questionId = q.Entity.QuestionID;
                            questionIds.Add(questionId);
                        }

                        // Get back both ids to write it in the QuestionsOnPoll table.
                        foreach (var questionId in questionIds)
                        {
                            var entry = context.QuestionOnPoll.Add(new QuestionsOnPoll
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

        [HttpGet("/polls")]
        public async Task<IActionResult> getAllPolls()
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    var polls = this.context.Poll.ToList();

                    if (polls == null || polls.Count == 0)
                    {
                        return NotFound("No Polls created.");
                    }
                    return Ok(polls);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching polls");

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching polls: " + ex);
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
                    var polls = this.context.Poll.Where(poll => poll.UserID == id);

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
        [HttpPost("/question/{questionid}/takequestion")]
        public async Task<IActionResult> answerQuestions([FromRoute] int questionid, [FromBody] AnswerDTO answer)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    var claim = User.Claims.FirstOrDefault(x => x.Type == "id").Value;
                    _ = int.TryParse(claim, out int userId);

                    var questions = this.context.Question.Where(questions => questions.QuestionID == questionid).ToList();
                    if(questions == null)
                    {
                        return NotFound("There is no question with this id.");
                    }

                    var answerEntity = this.context.Answer.AddAsync(new Answer
                    {
                        QuestionID = questionid,
                        UserID = userId,
                        Value = answer.Value,
                    });
                    await context.SaveChangesAsync();

                    return CreatedAtAction(nameof(answerQuestions), new { id = answerEntity.Result.Entity.AnswerID}, answerEntity.Result.Entity.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error taking a question");

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating the answer.: " + ex);
                }
            }
            else
            {
                return Unauthorized("You are not logged in.");
            }
        }

        // To Do.
        [HttpGet("/question/{id}/getAnswers")]
        public async Task<IActionResult> getAnswersToQuestion([FromRoute] int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var question = this.context.Question.Where(questions => questions.QuestionID == id);

                    if (question == null)
                    {
                        return NotFound("No Questions with the specified id:"+ id);
                    }

                    var answers = this.context.Answer.Where(answers => answers.QuestionID == id).ToList();
                    
                    if(answers.Count > 0)
                    {
                        return Ok(answers);
                    }
                    else
                    {
                        return NotFound("No answers to this question.");
                    }
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

        [HttpGet("/polls/{id}")]
        public async Task<IActionResult> getPoll(int id)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {

                    var poll = this.context.Poll.FirstOrDefault(poll => poll.PollID == id);

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
                    var questions = this.context.Question.Where(questions => questions.PollID == id).ToList();

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

        [HttpPost("/question/{questionid}/questionOptions")]
        public async Task<IActionResult> createQuestionOptions([FromRoute] int questionid, [FromBody] QuestionOptionDto questionOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (User.Identity.IsAuthenticated)
            {

                try
                {
                    var questionOption = context.questionOptions.Add(new QuestionOption
                    {
                        QuestionID = questionid,
                        Value = questionOptions.Value
                    });

                    await context.SaveChangesAsync();

                    return CreatedAtAction(nameof(createPoll), new { id = questionOption.Entity.QuestionOptionId}, questionOption.Entity);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating a QuestionOption");

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a QuestionOption.: " + ex);
                }
            }
            else
            {
                return Unauthorized("You are not logged in.");
            }

        }
    }
}
