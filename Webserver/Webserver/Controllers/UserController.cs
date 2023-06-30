using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpGet("/getUsernameFromCookie")]
        public string getUsernameFromSession()
        {
            if (User.Identity.IsAuthenticated)
            {
                return User.Identity.Name;
            }
            else
            {
                return "No User is logged in.";
            }
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="data">The User Data Transfer Object.</param>
        /// <returns>Returns the User data as Json object.</returns>
        [HttpPost("/users/")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto data){
            try
            {
                var username = this.context.User.Where(users => users.UserName == data.Username);
                foreach (var i in username)
                {
                    if(i.UserName == data.Username)
                    {
                        return StatusCode(StatusCodes.Status403Forbidden, "Username already taken.");
                    }
                }

                var user = context.User.Add(new User
                {
                    Lastname = data.Lastname,
                    Firstname = data.Firstname,
                    Email = data.Email,
                    BirthDate = data.BirthDate.Date.ToUniversalTime(),
                    Role = data.Role,
                    UserName = data.Username,
                    Password = data.Password,
                    
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
        /// <returns>Returns the User data as Json object, only if the Logged in User is the creator of the poll.</returns>
        [HttpGet("/users/self")]
        public IActionResult GetUserSelf()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claim = User.Claims.FirstOrDefault(x => x.Type == "id").Value;
                _ = int.TryParse(claim, out int userId);

                var user = this.context.User.FirstOrDefault(user => user.UserID == userId);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            else
            {
                return Unauthorized("You are not logged in.");
            }
        }

        [HttpGet("/users/{id}")]
        public IActionResult GetUser(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = this.context.User.FirstOrDefault(user => user.UserID == id);

                if (user == null)
                {
                    return NotFound();
                }

                user.Password = "";

                return Ok(user);
            }
            else
            {
                return Unauthorized("You are not logged in.");
            }
        }

        [HttpPost("/logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Redirect("/login");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to logout.");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error tying to logout.: " + ex);
            }
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {

            // Validate the request
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //trying to find a user
            try
            {
                var user = this.context.User.SingleOrDefault(x => x.UserName == request.Username && x.Password == request.Password);
                if(user != null)
                {
                    var claim = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim("id", user.UserID.ToString()),
                    };

                    var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return Ok();
                }

                return Unauthorized(new { message = "Invalid username or password" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to login.");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error trying to login.: " + ex);
            }
        }
    }
}
