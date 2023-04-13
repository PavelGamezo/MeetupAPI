using Meetup.BusinessLayer.Interfaces;
using MeetupAPI.Helpers;
using MeetupAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetupAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;

        public AccountController(
            IUserService userService,
            IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (await _userService.IsExist(model.Email, model.Password, model.UserName))
            {
                var authenticationResult = await _authenticationService.Login(model.UserName, model.Email, model.Password);

                return Ok(new
                {
                    token = authenticationResult.Token,
                    status = new Response { Status = "Success", Message = "User login successfully!" }
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (await _userService.IsExist(model.Email, model.Password, model.UserName))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            }
            var authenticationResult = await _authenticationService.Register(model.UserName, model.Email, model.Password);

            return Ok(new Response { Status = "Success", Message = $"User {authenticationResult.UserName} created successfully!" });
        }
    }
}
