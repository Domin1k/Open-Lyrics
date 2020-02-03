namespace Application.UseCases.Lyrics.Delete
{
    using Application.Interfaces.Repositories;
    using System;
    using System.Threading.Tasks;

    public class DeleteLyricUseCase<T> : IDeleteLyricInputHandler<T>
    {
        private readonly ILyricRepository _lyricRepository;

        public DeleteLyricUseCase(ILyricRepository lyricRepository)
        {
            _lyricRepository = lyricRepository;
        }
        public async Task HandleAsync(DeleteLyricInput input, IDeleteLyricOutputHandler<T> output)
        {
            var dbLyric = await _lyricRepository.GetAsync(input.Id);
            if (dbLyric == null)
            {
                output.BadRequest("The given lyric does not exist");
                return;
            }

            try
            {
                await _lyricRepository.DeleteAsync(dbLyric);
                output.Success($"Successfully deleted Lyric {dbLyric.Title}");
            }
            catch (Exception)
            {
                output.BadRequest("Deleting lyric failed.");
            }
        }
    }
}
