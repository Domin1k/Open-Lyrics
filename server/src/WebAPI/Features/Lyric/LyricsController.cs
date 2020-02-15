namespace WebAPI.Features.Lyric
{
    using Application.UseCases.Lyrics.Create;
    using Application.UseCases.Lyrics.Delete;
    using Application.UseCases.Lyrics.Details;
    using Application.UseCases.Lyrics.Edit;
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
        private readonly IEditLyricInputHandler<IActionResult> _editLyricInputHandler;
        private readonly IEditLyricOutputHandler<IActionResult> _editLyricOutputHandler;
        private readonly IDeleteLyricInputHandler<IActionResult> _deleteLyricInputHandler;
        private readonly IDeleteLyricOutputHandler<IActionResult> _deleteLyricOutputHandler;
        private readonly IDetailsLyricsInputHandler<IActionResult> _detailsLyricInputHandler;
        private readonly IDetailsLyricsOutputHandler<IActionResult> _detailsLyricOutputHandler;
        private readonly IAllLyricsInputHandler<IActionResult> _allLyricsInputHandler;
        private readonly IAllLyricsOutputHandler<IActionResult> _allLyricsOutputHandler;

        public LyricsController(
            ICreateLyricInputHandler<IActionResult> createLyricInputHandler,
            ICreateLyricOutputHandler<IActionResult> createLyricOutputHandler,
            IEditLyricInputHandler<IActionResult> editLyricInputHandler,
            IEditLyricOutputHandler<IActionResult> editLyricOutputHandler,
            IDeleteLyricInputHandler<IActionResult> deleteLyricInputHandler,
            IDeleteLyricOutputHandler<IActionResult> deleteLyricOutputHandler,
            IDetailsLyricsInputHandler<IActionResult> detailsLyricInputHandler,
            IDetailsLyricsOutputHandler<IActionResult> detailsLyricOutputHandler,
            IAllLyricsInputHandler<IActionResult> allLyricsInputHandler,
            IAllLyricsOutputHandler<IActionResult> allLyricsOutputHandler)
        {
            _createLyricInputHandler = createLyricInputHandler;
            _createLyricOutputHandler = createLyricOutputHandler;
            _editLyricInputHandler = editLyricInputHandler;
            _editLyricOutputHandler = editLyricOutputHandler;
            _deleteLyricInputHandler = deleteLyricInputHandler;
            _deleteLyricOutputHandler = deleteLyricOutputHandler;
            _detailsLyricInputHandler = detailsLyricInputHandler;
            _detailsLyricOutputHandler = detailsLyricOutputHandler;
            _allLyricsInputHandler = allLyricsInputHandler;
            _allLyricsOutputHandler = allLyricsOutputHandler;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateLyricRequest request)
        {
            await _createLyricInputHandler.HandleAsync(
                new CreateLyricInput { AuthorName = this.User.Identity.Name, Singer = request.Singer, Text = request.Text, Title = request.Title },
                _createLyricOutputHandler);
            return _createLyricOutputHandler.Result();
        }

        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, EditLyricRequest request)
        {
            await _editLyricInputHandler.HandleAsync(
                new EditLyricInput { Id = id, AuthorId = request.AuthorId, Singer = request.Singer, Text = request.Text, Title = request.Title },
                _editLyricOutputHandler);
            return _editLyricOutputHandler.Result();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteLyricInputHandler.HandleAsync(new DeleteLyricInput { Id = id }, _deleteLyricOutputHandler);
            return _deleteLyricOutputHandler.Result();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            await _detailsLyricInputHandler.HandleAsync(new DetailsLyricsInput { Id = id }, _detailsLyricOutputHandler);
            return _detailsLyricOutputHandler.Result();
        }

        [HttpGet("all")]
        public async Task<IActionResult> All([FromQuery]AllLyricsRequest request)
        {
            await _allLyricsInputHandler.HandleAsync(new AllLyricsInput { SearchTerm = request.SearchTerm, Page = request.Page, PageSize = request.PageSize }, _allLyricsOutputHandler);
            return _allLyricsOutputHandler.Result();
        }
    }
}
