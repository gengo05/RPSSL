using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Interfaces;
using RockPaperScissorsSpockLizard.Core.Utilities;

namespace RockPaperScissorsSpockLizard.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(User user)
        {
            try
            {
                string token = Guard.AgainstNullOrEmpty(userService.Login(user));
                return Ok(new { token });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "An error occurred during login." });
            }
        }
    }
}
