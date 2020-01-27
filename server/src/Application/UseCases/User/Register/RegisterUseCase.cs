namespace Application.UseCases.User.Register
{
    using Application.Interfaces.Repositories;
    using Domain.Entities;
    using System;
    using System.Threading.Tasks;

    public class RegisterUseCase : IRegisterInputHandler
    {
        private readonly IUserRepository _userRepository;

        public RegisterUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(CreateUserInput input, CreateUserOutput output)
        {
            var (passwordHash, passwordSalt) = CreatePasswordHash(input.Password);

            var user = new User(input.FirstName, input.LastName, input.Username, input.Email, passwordHash, passwordSalt, null);

            await _userRepository.CreateAsync(user);
            
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

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            // TODO refactor
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
