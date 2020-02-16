namespace WebAPI.Features.Lyric.Presenters
{
    using Application.UseCases.Lyrics.GetAll;
    using Microsoft.AspNetCore.Mvc;

    public class AllLyricsPresenter : IAllLyricsOutputHandler<IActionResult>
    {
        private IActionResult _result;

        public IActionResult Result() => _result;

        public void BadRequest(string msg)
            => _result = new BadRequestObjectResult(new
            {
                ErrorMessage = msg
            });

        public void Success(AllLyricsOutput output) => _result = new OkObjectResult(output);
    }
}
