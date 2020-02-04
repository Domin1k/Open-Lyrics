namespace Application.UseCases.User.Register
{
    public class RegisterUserInput
    {
        public RegisterUserInput(string firstName, string lastName, string username, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string Username { get;  }

        public string Email { get;  }

        public string Password { get; }
    }
}
