namespace WebAPI.Features.User.Models
{
    public class AuthenticateUserRequest
    {
        public string Username { get; }

        public string Password { get; }

        public string ConfirmPassword { get; }
    }
}
