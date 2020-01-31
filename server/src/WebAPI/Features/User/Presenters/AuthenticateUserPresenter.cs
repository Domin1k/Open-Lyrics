namespace WebAPI.Features.User.Presenters
{
    using Application.UseCases.User.Login;
    using Microsoft.AspNetCore.Mvc;

    public class AuthenticateUserPresenter : IAuthenticateOutputHandler<IActionResult>
    {
        private IActionResult _result;

        public IActionResult Result() => _result;

        public void BadRequest(string msg)
        {
            _result = new BadRequestObjectResult(new
            {
                ErrorMessage = msg
            });
        }

        public void Success(AuthenticateUserOutput output) => _result = new OkObjectResult(output);
    }
}
