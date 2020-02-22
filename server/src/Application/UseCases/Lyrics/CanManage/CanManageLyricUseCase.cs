namespace Application.UseCases.Lyrics.CanManage
{
    using Application.Interfaces.Repositories;
    using System.Threading.Tasks;

    public class CanManageLyricUseCase<T> : ICanManageLyricInputHandler<T>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILyricRepository _lyricRepository;

        public CanManageLyricUseCase(IUserRepository userRepository, ILyricRepository lyricRepository)
        {
            _userRepository = userRepository;
            _lyricRepository = lyricRepository;
        }
        public async Task HandleAsync(CanManageLyricInput input, ICanManageLyricOutputHandler<T> output)
        {
            var user = await _userRepository.GetByUsernameAsync(input.AuthorName);
            if (user == null)
            {
                output.BadRequest("User does not exists");
                return;
            }

            var lyricAuthorId = await _lyricRepository.GetAuthor(input.Id);
            
            var result = new CanManageLyricOutput
            {
                CanManage = user.Id == lyricAuthorId
            };

            output.Success(result);
        }
    }
}
