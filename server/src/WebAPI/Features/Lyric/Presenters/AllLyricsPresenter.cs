namespace WebAPI.Features.Lyric.Presenters
{
    using Application.UseCases.Lyrics.GetAll;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class AllLyricsPresenter : IAllLyricsOutputHandler<IActionResult>
    {
        private IActionResult _result;

        public IActionResult Result() => _result;

        public void BadRequest(string msg)
            => _result = new BadRequestObjectResult(new
            {
                ErrorMessage = msg
            });

        public void Success(IEnumerable<AllLyricsOutput> output) => _result = new OkObjectResult(output);
    }
}
