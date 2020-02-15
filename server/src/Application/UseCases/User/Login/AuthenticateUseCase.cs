namespace Application.UseCases.User.Login
{
    using Application.Interfaces;
    using Application.Interfaces.Repositories;
    using System;
    using System.Threading.Tasks;

    public class AuthenticateUseCase<T> : IAuthenticateInputHandler<T>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthenticateUseCase(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task HandleAsync(AuthenticateUserInput input, IAuthenticateOutputHandler<T> output)
        {
            var user = await _userRepository.GetByUsernameAsync(input.Username);

            if (user == null)
            {
                output.BadRequest("User does not exists");
            }

            if(!VerifyPasswordHash(input.Password, user.PasswordHash, user.PasswordSalt))
            {
                output.BadRequest("User credentials does not match");
            }   

            var token = _tokenService.GenerateJwtToken(user.Username.ToString());

            output.Success(new AuthenticateUserOutput(user.Id, user.Username, token));
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            // TODO refactor
            if (password == null) return false;
            if (string.IsNullOrWhiteSpace(password)) return false;

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
