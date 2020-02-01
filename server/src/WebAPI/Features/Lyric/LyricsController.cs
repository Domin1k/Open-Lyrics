namespace WebAPI.Features.Lyric
{
    using Application.UseCases.Lyrics.GetAll;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebAPI.Features.Lyric.Models;
    using WebAPI.Shared;

    [Authorize]
    public class LyricsController : BaseController
    {
        private readonly ICreateLyricInputHandler<IActionResult> _createLyricInputHandler;
        private readonly ICreateLyricOutputHandler<IActionResult> _createLyricOutputHandler;
        private readonly IAllLyricsInputHandler<IActionResult> _allLyricsInputHandler;
        private readonly IAllLyricsOutputHandler<IActionResult> _allLyricsOutputHandler;

        public LyricsController(
            ICreateLyricInputHandler<IActionResult> createLyricInputHandler,
            ICreateLyricOutputHandler<IActionResult> createLyricOutputHandler,
            IAllLyricsInputHandler<IActionResult> allLyricsInputHandler,
            IAllLyricsOutputHandler<IActionResult> allLyricsOutputHandler)
        {
            _createLyricInputHandler = createLyricInputHandler;
            _createLyricOutputHandler = createLyricOutputHandler;
            _allLyricsInputHandler = allLyricsInputHandler;
            _allLyricsOutputHandler = allLyricsOutputHandler;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateLyricRequest request)
        {
            await _createLyricInputHandler.HandleAsync(new CreateLyricInput { AuthorId = request.AuthorId, Singer = request.Singer, Text = request.Text, Title = request.Title }, _createLyricOutputHandler);
            return _createLyricOutputHandler.Result();
        }

        [HttpGet("all")]
        public async Task<IActionResult> All([FromQuery]AllLyricsRequest request)
        {
            await _allLyricsInputHandler.HandleAsync(new AllLyricsInput { Page = request.Page, PageSize = request.PageSize }, _allLyricsOutputHandler);
            return _allLyricsOutputHandler.Result();
        }
    }
}
