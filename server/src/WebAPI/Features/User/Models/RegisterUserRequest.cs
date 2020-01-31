namespace WebAPI.Features.User.Models
{
    public class RegisterUserRequest
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Username { get; }

        public string Email { get; }

        public string Password { get; }

        public string ConfirmPassword { get; }
    }
}
