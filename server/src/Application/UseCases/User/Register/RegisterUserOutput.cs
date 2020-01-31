namespace Application.UseCases.User.Register
{
    public class RegisterUserOutput
    {
        public RegisterUserOutput(int id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }

        public int Id { get; }

        public string Username { get; }

        public string Email { get; }
    }
}
