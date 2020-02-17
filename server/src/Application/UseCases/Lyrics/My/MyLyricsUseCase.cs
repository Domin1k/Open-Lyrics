namespace Application.UseCases.Lyrics.My
{
    using Application.Interfaces.Repositories;
    using System.Linq;
    using System.Threading.Tasks;

    public class MyLyricsUseCase<T> : IMyLyricsInputHandler<T>
    {
        private readonly ILyricRepository _lyricRepository;

        public MyLyricsUseCase(ILyricRepository lyricRepository)
        {
            _lyricRepository = lyricRepository;
        }
        public async Task HandleAsync(MyLyricsInput input, IMyLyricsOutputHandler<T> output)
        {
            var lyrics = await _lyricRepository.GetAllQueryAsync(x => x.Author.Username == input.AuthorUsername, input.Page, input.PageSize);

            var result = lyrics.Select(x => new MyLyricOutput(x.Id, x.Text, x.Title, x.Singer, x.AuthorId, x.Author.Username));

            output.Success(new MyLyricsOutput(result, input.IncludeCount ? await _lyricRepository.CountAsync(x => x.Author.Username == input.AuthorUsername) : 0));
        }
    }
}
