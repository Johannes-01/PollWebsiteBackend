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

        [HttpPost("/users/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {


            // Validate the request
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = this.context.Users
            }
            catch (Exception)
            {

                throw;
            }



            // Check if the user exists in the database
            //var user = await this.context.GetUserByUsernameAsync(request.Username);
            var user;
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            // Check if the password is correct
            //var isPasswordValid = await _userService.CheckPasswordAsync(user, request.Password);
            var isPasswordValid;
            if (!isPasswordValid)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            // If the credentials are valid, create a JWT token and return it to the client
           // var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

    }
}
