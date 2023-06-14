﻿using Microsoft.AspNetCore.Mvc;
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
                        Created = DateTime.Now,
                    });
                    #region test
                    /*{
                      "title": "title",
                      "description": "description",
                      "author": 1,
                      "startDate": "2023-06-13T22:02:40.585Z",
                      "endDate": "2023-07-13T22:02:40.585Z",
                      "questions": [
                        {
                          "description": "description1",
                          "heading": "question1",
                          "index": 1,
                          "type": 1
                        },
                        {
                          "description": "description2",
                          "heading": "question2",
                          "index": 2,
                          "type": 1
                        }
                      ]
                    }*/
                    #endregion
                    // get back of id not correct
                    //var pollId = poll.Property("PollId");
                    var pollId = poll.Property(e => e.PollID).CurrentValue;

                    List<int> questionIds = new List<int>();

                    foreach (var question in data.questions)
                    {
                        var q = context.Questions.Add(new Question
                        {
                            description = data.questions[0].ToString(),
                            heading = data.questions[1].ToString(),
                            index = data.questions[2].Index,
                            survey_id = pollId,
                            type = data.questions[4].Type,
                        });

                        context.SaveChangesAsync();
                        var questionId = q.Property(e => e.id).CurrentValue;
                        questionIds.Add(questionId);
                    }

                    // Get back both ids to write it in the QuestionsonPoll table.
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
            // TO Do: Also Return Questions from Poll or write new Query.
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
    }
}
