﻿namespace WebAPI.Features.Lyric
{
    using Application.UseCases.Lyrics.CanManage;
    using Application.UseCases.Lyrics.Create;
    using Application.UseCases.Lyrics.Delete;
    using Application.UseCases.Lyrics.Details;
    using Application.UseCases.Lyrics.Edit;
    using Application.UseCases.Lyrics.GetAll;
    using Application.UseCases.Lyrics.My;
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
        private readonly IMyLyricsInputHandler<IActionResult> _myLyricsInputHandler;
        private readonly IMyLyricsOutputHandler<IActionResult> _myLyricsOutputHandler;
        private readonly ICanManageLyricInputHandler<IActionResult> _canManageLyricInputHandler;
        private readonly ICanManageLyricOutputHandler<IActionResult> _canManageLyricOutputHandler;

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
            IAllLyricsOutputHandler<IActionResult> allLyricsOutputHandler,
            IMyLyricsInputHandler<IActionResult> myLyricsInputHandler,
            IMyLyricsOutputHandler<IActionResult> myLyricsOutputHandler,
            ICanManageLyricInputHandler<IActionResult> canManageLyricInputHandler,
            ICanManageLyricOutputHandler<IActionResult> canManageLyricOutputHandler)
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
            _myLyricsInputHandler = myLyricsInputHandler;
            _myLyricsOutputHandler = myLyricsOutputHandler;
            _canManageLyricInputHandler = canManageLyricInputHandler;
            _canManageLyricOutputHandler = canManageLyricOutputHandler;
        }

        [HttpGet("canManage/{id:int}")]
        public async Task<IActionResult> CanManage(int id)
        {
            await _canManageLyricInputHandler.HandleAsync(new CanManageLyricInput { Id = id, AuthorName = User.Identity.Name }, _canManageLyricOutputHandler);
            return _canManageLyricOutputHandler.Result();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateLyricRequest request)
        {
            await _createLyricInputHandler.HandleAsync(
                new CreateLyricInput { AuthorName = User.Identity.Name, Singer = request.Singer, Text = request.Text, Title = request.Title },
                _createLyricOutputHandler);
            return _createLyricOutputHandler.Result();
        }

        [HttpPut("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, EditLyricRequest request)
        {
            await _editLyricInputHandler.HandleAsync(
                new EditLyricInput { Id = id, AuthorUsername = User.Identity.Name, Singer = request.Singer, Text = request.Text, Title = request.Title },
                _editLyricOutputHandler);
            return _editLyricOutputHandler.Result();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteLyricInputHandler.HandleAsync(new DeleteLyricInput { Id = id }, _deleteLyricOutputHandler);
            return _deleteLyricOutputHandler.Result();
        }

        [HttpGet("details/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            await _detailsLyricInputHandler.HandleAsync(new DetailsLyricsInput { Id = id }, _detailsLyricOutputHandler);
            return _detailsLyricOutputHandler.Result();
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllLyricsRequest request)
        {
            await _allLyricsInputHandler.HandleAsync(new AllLyricsInput
            {
                IncludeCount = request.IncludeCount,
                SearchTerm = request.SearchTerm,
                Page = request.Page > 0 ? request.Page : 0,
                PageSize = request.PageSize > 0 ? request.PageSize : 0
            },
            _allLyricsOutputHandler);
            return _allLyricsOutputHandler.Result();
        }

        [HttpGet("my")]
        public async Task<IActionResult> My([FromQuery]MyLyricsRequest request)
        {
            await _myLyricsInputHandler.HandleAsync(new MyLyricsInput
            {
                IncludeCount = request.IncludeCount,
                AuthorUsername = User.Identity.Name,
                Page = request.Page > 0 ? request.Page : 0,
                PageSize = request.PageSize > 0 ? request.PageSize : 0
            },
            _myLyricsOutputHandler);
            return _myLyricsOutputHandler.Result();
        }
    }
}
