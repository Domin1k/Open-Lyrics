namespace Application.UseCases.User.Register
{
    using Application.Interfaces.Repositories;
    using Domain.Entities;
    using System;
    using System.Threading.Tasks;

    public class RegisterUseCase<T> : IRegisterInputHandler<T>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(RegisterUserInput input, IRegisterOutputHandler<T> output)
        {
            var (passwordHash, passwordSalt) = CreatePasswordHash(input.Password);

            var user = new User(input.FirstName, input.LastName, input.Username, input.Email, passwordHash, passwordSalt, null);

            await _userRepository.CreateAsync(user);

            output.Success(new RegisterUserOutput(user.Id, user.Username, user.Email));
        }

        private (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password)
        {
            byte[] passwordSalt;
            byte[] passwordHash;
            // TODO refactor
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            return (passwordHash, passwordSalt);
        }

        /*
         * Will be used for Authentication
         * private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            // TODO refactor
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }*/
    }
}
