using eCommerce.Core.DTOs;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace eCommerce.API.Contrrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerRequest)
         {
            if (registerRequest == null)
                NullRequest();

            var registerResponse = await _userService.Register(registerRequest!);

            if (registerResponse == null || !registerResponse.IsSuccess)
                return Problem(
                    title: "Registratioon Failed",
                    detail: "Unable to register user",
                    statusCode: StatusCodes.Status400BadRequest);

            var response = _tokenService.GenerateToken(registerResponse);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginRequest)
        {
            if (loginRequest == null)
                NullRequest();

            var loginResponse = await _userService.Login(loginRequest!);

            if (loginResponse == null || !loginResponse.IsSuccess)
                return Problem(
                    title: "Login Failed",
                    detail: "Unable to login user",
                    statusCode: StatusCodes.Status401Unauthorized);

            var response = _tokenService.GenerateToken(loginResponse);
            return Ok(response);
        }

        private ObjectResult NullRequest()
        {
            return Problem(
                title: "InvalidRequest",
                detail: "Request is null",
                statusCode: StatusCodes.Status400BadRequest);

        }
    }
}
