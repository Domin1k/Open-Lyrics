namespace Application.UseCases.Lyrics.Edit
{
    using Application.Interfaces.Repositories;
    using System;
    using System.Threading.Tasks;

    public class EditLyricUseCase<T> : IEditLyricInputHandler<T>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILyricRepository _lyricRepository;

        public EditLyricUseCase(IUserRepository userRepository, ILyricRepository lyricRepository)
        {
            _userRepository = userRepository;
            _lyricRepository = lyricRepository;
        }
        public async Task HandleAsync(EditLyricInput input, IEditLyricOutputHandler<T> output)
        {
            var authorExists = await _userRepository.ExistsAsync(input.AuthorId);
            if (!authorExists)
            {
                output.BadRequest("The given author does not exist");
                return;
            }

            var dbLyric = await _lyricRepository.GetAsync(input.Id);
            if (dbLyric == null)
            {
                output.BadRequest("The given lyric does not exist");
                return;
            }
            try
            {
                dbLyric.Title = input.Title;
                dbLyric.Text = input.Text;
                dbLyric.Singer = input.Singer;
                
                await _lyricRepository.UpdateAsync(dbLyric);
                output.Success(new EditLyricOutput(dbLyric.Id, dbLyric.Text, dbLyric.Title, dbLyric.Singer));
            }
            catch (Exception)
            {
                output.BadRequest("Editing lyric failed.");
            }
        }
    }
}
