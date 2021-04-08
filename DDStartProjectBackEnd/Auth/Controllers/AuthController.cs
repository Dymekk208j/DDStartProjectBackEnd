using DDStartProjectBackEnd.Auth.Data.Services.Interfaces;
using DDStartProjectBackEnd.Auth.Dto.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.Auth.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;

        public AuthController(IAuthService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _userService.Register(request);

            if (response.IsSuccess)
            {
                return Accepted();
            }

            return BadRequest(response.Errors);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            var loginResult = await _userService.Login(request);
            if (loginResult == null)
                return Unauthorized();

            return Ok(loginResult);
        }

        [HttpGet("IsEmailAvailable")]
        public async Task<IActionResult> IsEmailAvailable([FromQuery] IsEmailAvailableRequest request)
        {
            var response = await _userService.IsEmailAvailable(request);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpGet("IsUsernameAvailable")]
        public async Task<IActionResult> IsUsernameAvailable([FromQuery]IsUsernameAvailableRequest request)
        {
            var response = await _userService.IsUsernameAvailable(request);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }
    }
}