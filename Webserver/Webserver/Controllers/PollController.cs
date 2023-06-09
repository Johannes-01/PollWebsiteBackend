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
                    });
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
