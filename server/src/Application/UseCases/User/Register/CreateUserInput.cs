namespace Application.UseCases.User.Register
{
    public class CreateUserInput
    {
        public CreateUserInput(string firstName, string lastName, string username, string email, string password, string confirmPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string Username { get;  }

        public string Email { get;  }

        public string Password { get; }
        
        public string ConfirmPassword { get;  }
    }
}
