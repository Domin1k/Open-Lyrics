namespace Application.UseCases.Lyrics.GetAll
{
    using Application.Interfaces.Repositories;
    using Domain.Entities;
    using System;
    using System.Threading.Tasks;

    public class CreateLyricUseCase<T> : ICreateLyricInputHandler<T>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILyricRepository _lyricRepository;

        public CreateLyricUseCase(IUserRepository userRepository, ILyricRepository lyricRepository)
        {
            _userRepository = userRepository;
            _lyricRepository = lyricRepository;
        }
        public async Task HandleAsync(CreateLyricInput input, ICreateLyricOutputHandler<T> output)
        {
            var authorExists = await _userRepository.ExistsAsync(input.AuthorId);
            if (!authorExists)
            {
                output.BadRequest("The given author does not exist");
                return;
            }

            var dbLyric = new Lyric
            {
                CreatedOn = DateTime.UtcNow,
                AuthorId = input.AuthorId,
                Singer = input.Singer,
                Text = input.Text,
                Title = input.Title,
            };
            try
            {
                await _lyricRepository.CreateAsync(dbLyric);
                output.Success(new CreateLyricOutput(dbLyric.Id));
            }
            catch (Exception)
            {
                output.BadRequest("Creating lyric failed.");
            }
        }
    }
}
