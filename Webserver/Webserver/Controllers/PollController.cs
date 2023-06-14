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

                    foreach (var question in data.questions)
                    {
                        var q = context.Questions.Add(new Question
                        {
                            description = question.Description,
                            heading = question.Heading,
                            index = question.Index,
                            survey_id = pollId,
                            type = question.Type,
                        });

                        context.Questions.Add(q.Entity);
                        await context.SaveChangesAsync();

                        var questionId = q.Entity.id;
                        questionIds.Add(questionId);
                    }

                    // Get back both ids to write it in the QuestionsOnPoll table.
                    foreach (var questionId in questionIds)
                    {
                        var entry = context.questionsOnPolls.Add(new QuestionsOnPoll
                        {
                            PollId = pollId,
                            QuestionId = questionId,
                        });
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


        [HttpGet("/polls/{id}")]
        public async Task<IActionResult> getPoll(int id)
        {
            //to do: only let user who created this poll fetch the poll! Same with questions!
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
                    var questions = this.context.Questions.Where(questions => questions.survey_id == id).ToList();

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
