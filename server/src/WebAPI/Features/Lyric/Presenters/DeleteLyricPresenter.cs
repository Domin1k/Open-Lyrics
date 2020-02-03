namespace WebAPI.Features.Lyric.Presenters
{
    using Application.UseCases.Lyrics.Delete;
    using Microsoft.AspNetCore.Mvc;

    public class DeleteLyricPresenter : IDeleteLyricOutputHandler<IActionResult>
    {
        private IActionResult _result;

        public IActionResult Result() => _result;

        public void BadRequest(string msg)
            => _result = new BadRequestObjectResult(new
            {
                ErrorMessage = msg
            });

        public void Success(string output) => _result = new OkObjectResult(output);
    }
}
