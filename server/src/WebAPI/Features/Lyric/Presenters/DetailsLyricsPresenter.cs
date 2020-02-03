namespace WebAPI.Features.Lyric.Presenters
{
    using Application.UseCases.Lyrics.Details;
    using Microsoft.AspNetCore.Mvc;

    public class DetailsLyricsPresenter : IDetailsLyricsOutputHandler<IActionResult>
    {
        private IActionResult _result;

        public IActionResult Result() => _result;

        public void BadRequest(string msg)
            => _result = new BadRequestObjectResult(new
            {
                ErrorMessage = msg
            });

        public void Success(DetailsLyricsOutput output) => _result = new OkObjectResult(output);
    }
}
