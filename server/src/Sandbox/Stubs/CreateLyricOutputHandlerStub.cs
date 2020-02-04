namespace Sandbox.Stubs
{
    using Application.UseCases.Lyrics.Create;
    using Application.UseCases.User.Register;
    using System;

    public class CreateLyricOutputHandlerStub : ICreateLyricOutputHandler<Action>
    {
        public void BadRequest(string msg)
        {
        }

        public Action Result()
        {
            return () => { };
        }

        public void Success(CreateLyricOutput output)
        {
            
        }
    }
}
