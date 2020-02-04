namespace Sandbox.Stubs
{
    using Application.UseCases.User.Register;
    using System;

    public class RegisterOutputHandlerStub : IRegisterOutputHandler<Action>
    {
        public void BadRequest(string msg)
        {
        }

        public Action Result()
        {
            return () => { };
        }

        public void Success(RegisterUserOutput output)
        {
            
        }
    }
}
