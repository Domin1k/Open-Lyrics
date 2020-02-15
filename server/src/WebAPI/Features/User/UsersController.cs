namespace WebAPI.Features.User
{
    using Application.UseCases.User.Login;
    using Application.UseCases.User.Register;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Distributed;
    using System.Threading.Tasks;
    using WebAPI.Features.User.Models;
    using WebAPI.Shared;


    [Authorize]
    public class UsersController : BaseController
    {
        private readonly IRegisterInputHandler<IActionResult> _registerInputHandler;
        private readonly IAuthenticateInputHandler<IActionResult> _authInputHandler;
        private readonly IRegisterOutputHandler<IActionResult> _registerOutputHandler;
        private readonly IAuthenticateOutputHandler<IActionResult> _authOutputHandler;
        private readonly IDistributedCache _cache;

        public UsersController(
            IRegisterInputHandler<IActionResult> registerInputHandler, 
            IRegisterOutputHandler<IActionResult> registerOutputHandler,
            IAuthenticateInputHandler<IActionResult> authInputHandler,
            IAuthenticateOutputHandler<IActionResult> authOutputHandler,
            IDistributedCache cache)
        {
            _registerInputHandler = registerInputHandler;
            _registerOutputHandler = registerOutputHandler;
            _authInputHandler = authInputHandler;
            _authOutputHandler = authOutputHandler;
            _cache = cache;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                // TODO use FluentValidation
                return BadRequest("Password and ConfirmPassword does not match");
            }
            var registerUserInput = new RegisterUserInput(request.FirstName, request.LastName, request.Username, request.Email, request.Password);
            await _registerInputHandler.HandleAsync(registerUserInput, _registerOutputHandler);
            return _registerOutputHandler.Result();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateUser(AuthenticateUserRequest request)
        {
            await InvalidateExistingAccessToken();
            var authInput = new AuthenticateUserInput(request.Username, request.Password);
            await _authInputHandler.HandleAsync(authInput, _authOutputHandler);
            return _authOutputHandler.Result();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> InvalidateToken()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (accessToken != null)
            {
                await _cache.SetStringAsync($"{Constants.JwtTokenKey}{User.Identity.Name}", accessToken);
            }

            return Ok();
        }

        [HttpGet("noauth")]
        [AllowAnonymous]
        public IActionResult NoAuth()
        {
            return Ok("Hello from No Auth");
        }

        [HttpGet("auth")]
        public IActionResult Auth()
        {
            return Ok("Hello from Auth");
        }

        private async Task InvalidateExistingAccessToken()
        {
            var key = $"{Constants.JwtTokenKey}{User.Identity.Name}";
            var accessToken = await _cache.GetStringAsync(key);
            if (accessToken != null)
            {
                await _cache.SetStringAsync(key, accessToken);
            }
        }
    }
}
