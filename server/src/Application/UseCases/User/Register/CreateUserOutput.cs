namespace Application.UseCases.User.Register
{
    public class CreateUserOutput
    {
        public CreateUserOutput(int id, string username, string email, string token)
        {
            Id = id;
            Username = username;
            Email = email;
            Token = token;
        }

        public int Id { get; }

        public string Username { get; }

        public string Email { get; }

        public string Token { get; }
    }
}
