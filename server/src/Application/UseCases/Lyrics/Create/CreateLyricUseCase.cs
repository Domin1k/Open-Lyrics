namespace Application.UseCases.Lyrics.Create
{
    using Application.Interfaces.Repositories;
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            var author = await _userRepository.GetByUsernameAsync(input.AuthorName);
            if (author == null)
            {
                output.BadRequest("The given author does not exist");
                return;
            }

            var dbLyric = new Lyric
            {
                CreatedOn = DateTime.UtcNow,
                AuthorId = author.Id,
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

        public async Task HandleAsync(IEnumerable<CreateLyricInput> inputs, ICreateLyricOutputHandler<T> output)
        {
            var dbLyrics = inputs.Select(input => new Lyric
            {
                CreatedOn = DateTime.UtcNow,
               // AuthorId = author.Id,
                Singer = input.Singer,
                Text = input.Text,
                Title = input.Title,
            });
            try
            {
                await _lyricRepository.CreateManyAsync(dbLyrics);
                output.Success(new CreateLyricOutput(0));
            }
            catch (Exception)
            {
                output.BadRequest("Creating lyric failed.");
            }
        }
    }
}
