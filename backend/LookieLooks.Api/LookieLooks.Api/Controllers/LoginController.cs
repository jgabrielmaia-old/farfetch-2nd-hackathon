using LookieLooks.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LookieLooks.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUser(string username)
        {
            string userName = _userService.GetUserId(username);
            return Ok(userName);
        }
    }
}
