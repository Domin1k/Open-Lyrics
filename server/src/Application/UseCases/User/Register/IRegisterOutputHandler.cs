namespace Application.UseCases.User.Register
{
    public interface IRegisterOutputHandler<T>
    {
        T Result();

        void Success(RegisterUserOutput output);

        void BadRequest(string msg);
    }
}
