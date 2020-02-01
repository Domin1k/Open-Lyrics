namespace Application.UseCases.Lyrics.GetAll
{
    using Application.Interfaces.Repositories;
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
            var lyrics = await _lyricRepository.GetAllNonDeletedAsync(input.Page, input.PageSize);
            var result = lyrics.Select(x => new AllLyricsOutput(x.Id, x.Text, x.Title, x.Singer, x.AuthorId, x.Author.Username));
            output.Success(result.ToList());
        }
    }
}
