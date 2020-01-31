namespace WebAPI.Features.User.Presenters
{
    using Application.UseCases.User.Register;
    using Microsoft.AspNetCore.Mvc;

    public class RegisterUserPresenter : IRegisterOutputHandler<IActionResult>
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

        public void Success(RegisterUserOutput output) => _result = new CreatedResult(string.Empty, output.Id);
    }
}
