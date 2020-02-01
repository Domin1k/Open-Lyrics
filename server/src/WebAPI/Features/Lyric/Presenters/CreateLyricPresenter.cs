namespace WebAPI.Features.Lyric.Presenters
{
    using Application.UseCases.Lyrics.GetAll;
    using Microsoft.AspNetCore.Mvc;

    public class CreateLyricPresenter : ICreateLyricOutputHandler<IActionResult>
    {
        private IActionResult _result;

        public IActionResult Result() => _result;

        public void BadRequest(string msg)
            => _result = new BadRequestObjectResult(new
            {
                ErrorMessage = msg
            });

        public void Success(CreateLyricOutput output) => _result = new CreatedResult(string.Empty, output.Id);
    }
}
