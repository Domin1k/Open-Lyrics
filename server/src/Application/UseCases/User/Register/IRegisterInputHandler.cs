namespace Application.UseCases.User.Register
{
    using System.Threading.Tasks;

    public interface IRegisterInputHandler<T>
    {
        Task HandleAsync(RegisterUserInput input, IRegisterOutputHandler<T> output);
    }
}
