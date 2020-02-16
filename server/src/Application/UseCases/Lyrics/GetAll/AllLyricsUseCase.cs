namespace Application.UseCases.Lyrics.GetAll
{
    using Application.Interfaces.Repositories;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AllLyricsUseCase<T> : IAllLyricsInputHandler<T>
    {
        private readonly ILyricRepository _lyricRepository;

        public AllLyricsUseCase(ILyricRepository lyricRepository)
        {
            _lyricRepository = lyricRepository;
        }
        public async Task HandleAsync(AllLyricsInput input, IAllLyricsOutputHandler<T> output)
        {
            IEnumerable<Lyric> lyrics;
            if (string.IsNullOrEmpty(input.SearchTerm))
            {
                lyrics = await _lyricRepository.GetAllNonDeletedAsync(input.Page, input.PageSize);
            }
            else
            {
                lyrics = await _lyricRepository.GetAllQueryAsync(x => x.Singer.Contains(input.SearchTerm), input.Page, input.PageSize);
            }
           var result = lyrics.Select(x => new AllLyricOutput(x.Id, x.Text, x.Title, x.Singer, x.AuthorId, x.Author.Username));
            
            output.Success(new AllLyricsOutput(result, input.IncludeCount ? await _lyricRepository.CountAsync() : 0));
        }
    }
}
