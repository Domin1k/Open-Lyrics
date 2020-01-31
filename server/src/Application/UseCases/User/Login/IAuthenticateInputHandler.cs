namespace Application.UseCases.User.Login
{
    using System.Threading.Tasks;

    public interface IAuthenticateInputHandler<T>
    {
        Task HandleAsync(AuthenticateUserInput input, IAuthenticateOutputHandler<T> output);
    }
}
