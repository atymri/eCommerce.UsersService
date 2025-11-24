using eCommerce.Core.DTOs;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Contrrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerRequest)
         {
            if (registerRequest == null)
                NullRequest();

            var response = await _userService.Register(registerRequest!);

            if (response == null || !response.IsSuccess)
                return Problem(
                    title: "Registratioon Failed",
                    detail: "Unable to register user",
                    statusCode: StatusCodes.Status400BadRequest);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginRequest)
        {
            if (loginRequest == null)
                NullRequest();

            var response = await _userService.Login(loginRequest!);

            if (response == null || !response.IsSuccess)
                return Problem(
                    title: "Login Failed",
                    detail: "Unable to login user",
                    statusCode: StatusCodes.Status401Unauthorized);

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
