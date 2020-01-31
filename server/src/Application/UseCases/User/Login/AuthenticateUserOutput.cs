namespace Application.UseCases.User.Login
{
    public class AuthenticateUserOutput
    {
        public AuthenticateUserOutput(int id, string username, string token)
        {
            Id = id;
            Username = username;
            Token = token;
        }

        public int Id { get; }

        public string Username { get; }

        public string Token { get; }
    }
}
