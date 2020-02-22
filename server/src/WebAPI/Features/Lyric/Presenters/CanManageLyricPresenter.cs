namespace WebAPI.Features.Lyric.Presenters
{
    using Application.UseCases.Lyrics.CanManage;
    using Microsoft.AspNetCore.Mvc;

    public class CanManageLyricPresenter : ICanManageLyricOutputHandler<IActionResult>
    {
        private IActionResult _result;

        public IActionResult Result() => _result;

        public void BadRequest(string msg)
            => _result = new BadRequestObjectResult(new
            {
                ErrorMessage = msg
            });

        public void Success(CanManageLyricOutput output) => _result = new OkObjectResult(output);
    }
}
