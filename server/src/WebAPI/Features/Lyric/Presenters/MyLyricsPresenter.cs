namespace WebAPI.Features.Lyric.Presenters
{
    using Application.UseCases.Lyrics.My;
    using Microsoft.AspNetCore.Mvc;

    public class MyLyricsPresenter : IMyLyricsOutputHandler<IActionResult>
    {
        private IActionResult _result;

        public IActionResult Result() => _result;

        public void BadRequest(string msg)
            => _result = new BadRequestObjectResult(new
            {
                ErrorMessage = msg
            });

        public void Success(MyLyricsOutput output) => _result = new OkObjectResult(output);
    }
}
