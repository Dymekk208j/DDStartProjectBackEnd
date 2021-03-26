using DDStartProjectBackEnd.Auth.Requests;
using DDStartProjectBackEnd.Auth.Services.Interfaces;
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
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _userService.Register(request);

            if (response.IsSuccess)
            {
                return Accepted();
            }

            return BadRequest(response.Errors);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginResult = await _userService.Login(request);

            if (loginResult == null)
                return Unauthorized();

            return Ok(loginResult);
        }
    }
}