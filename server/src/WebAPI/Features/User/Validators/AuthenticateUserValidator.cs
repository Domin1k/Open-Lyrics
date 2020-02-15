namespace WebAPI.Features.User.Validators
{
    using FluentValidation;
    using WebAPI.Features.User.Models;

    public class AuthenticateUserValidator : AbstractValidator<AuthenticateUserRequest>
    {
        public AuthenticateUserValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(6);
        }
    }
}
