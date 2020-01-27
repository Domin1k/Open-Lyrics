using System.Threading.Tasks;

namespace Application.UseCases.User.Register
{
    public interface IRegisterInputHandler
    {
        Task HandleAsync(CreateUserInput input, CreateUserOutput output);
    }

    public interface IRegisterOutputHandler
    {
        void Success(CreateUserOutput output);

        void BadRequest(string msg);
    }
}
