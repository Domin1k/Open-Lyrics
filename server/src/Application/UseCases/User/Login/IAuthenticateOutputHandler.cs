namespace Application.UseCases.User.Login
{
    public interface IAuthenticateOutputHandler<T>
    {
        T Result();

        void Success(AuthenticateUserOutput output);

        void BadRequest(string msg);
    }
}
