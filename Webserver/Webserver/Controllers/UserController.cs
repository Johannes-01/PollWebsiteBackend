using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webserver.Context;
using Webserver.DTOs;
using Webserver.Model;

namespace Webserver.Controllers
{
    public class UserController : Controller
    {
        private readonly PollDbContext context;
        private readonly ILogger<UserController> _logger;

        public UserController(PollDbContext context, ILogger<UserController> logger)
        {
            this.context = context;
            this._logger = logger;
        }


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="data">The User Data Transfer Object.</param>
        /// <returns>Returns the User data as Json object.</returns>
        [HttpPost("/users/")]
        public async Task<IActionResult> CreateUser(UserDto data){

            var date = data.BirthDate.ToUniversalTime().ToString("yyyy'-'MM'-'dd");
            try
            {
                var user = context.Users.Add(new User
                {
                    Lastname = data.Lastname,
                    Firstname = data.Firstname,
                    Email = data.Email,
                    BirthDate = data.BirthDate.Date.ToUniversalTime(),
                    Role = data.Role,
                });
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateUser), new { id = user.Entity.UserID }, user.Entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating item");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a User.: "+ex);
            }
        }

        /// <summary>
        /// Get a specific User via the ID.
        /// </summary>
        /// <param name="id">The User ID.</param>
        /// <returns>Returns the User data as Json object.</returns>
        [HttpGet("/users/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = this.context.Users.FirstOrDefault(user => user.UserID == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
