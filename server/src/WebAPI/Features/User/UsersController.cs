namespace WebAPI.Features.User
{
    using Application.UseCases.User.Login;
    using Application.UseCases.User.Register;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebAPI.Features.User.Models;
    using WebAPI.Shared;

    public class UsersController : BaseController
    {
        private readonly IRegisterInputHandler<IActionResult> _registerInputHandler;
        private readonly IAuthenticateInputHandler<IActionResult> _authInputHandler;
        private readonly IRegisterOutputHandler<IActionResult> _registerOutputHandler;
        private readonly IAuthenticateOutputHandler<IActionResult> _authOutputHandler;

        public UsersController(
            IRegisterInputHandler<IActionResult> registerInputHandler, 
            IRegisterOutputHandler<IActionResult> registerOutputHandler,
            IAuthenticateInputHandler<IActionResult> authInputHandler,
            IAuthenticateOutputHandler<IActionResult> authOutputHandler)
        {
            _registerInputHandler = registerInputHandler;
            _registerOutputHandler = registerOutputHandler;
            _authInputHandler = authInputHandler;
            _authOutputHandler = authOutputHandler;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
        {
            var registerUserInput = new RegisterUserInput(request.FirstName, request.LastName, request.Username, request.Email, request.Password, request.ConfirmPassword);
            await _registerInputHandler.HandleAsync(registerUserInput, _registerOutputHandler);
            return _registerOutputHandler.Result();
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateUser(AuthenticateUserRequest request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                // TODO use FluentValidation
                return BadRequest("Password and ConfirmPassword does not match");
            }

            var authInput = new AuthenticateUserInput(request.Username, request.Password);
            await _authInputHandler.HandleAsync(authInput, _authOutputHandler);
            return _authOutputHandler.Result();
        }
    }
}
