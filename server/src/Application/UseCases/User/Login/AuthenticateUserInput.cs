namespace Application.UseCases.User.Login
{
    public class AuthenticateUserInput
    {
        public AuthenticateUserInput(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get;  }

        public string Password { get; }
    }
}
