namespace WebAPI.Features.Lyric.Presenters
{
    using Application.UseCases.Lyrics.Edit;
    using Microsoft.AspNetCore.Mvc;

    public class EditLyricPresenter : IEditLyricOutputHandler<IActionResult>
    {
        private IActionResult _result;

        public IActionResult Result() => _result;

        public void BadRequest(string msg)
            => _result = new BadRequestObjectResult(new
            {
                ErrorMessage = msg
            });

        public void Success(EditLyricOutput output) => _result = new OkObjectResult(output);
    }
}
