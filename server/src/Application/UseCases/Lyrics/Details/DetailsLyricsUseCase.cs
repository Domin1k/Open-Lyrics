namespace Application.UseCases.Lyrics.Details
{
    using Application.Interfaces.Repositories;
    using System.Linq;
    using System.Threading.Tasks;

    public class DetailsLyricsUseCase<T> : IDetailsLyricsInputHandler<T>
    {
        private readonly ILyricRepository _lyricRepository;

        public DetailsLyricsUseCase(ILyricRepository lyricRepository)
        {
            _lyricRepository = lyricRepository;
        }
        public async Task HandleAsync(DetailsLyricsInput input, IDetailsLyricsOutputHandler<T> output)
        {
            var lyric = await _lyricRepository.GetAsync(input.Id);
            var result = new DetailsLyricsOutput(lyric.Id, lyric.Text, lyric.Title, lyric.Singer, lyric.AuthorId, lyric.Author.Username);

            output.Success(result);
        }
    }
}
