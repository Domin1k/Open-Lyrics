namespace Application.UseCases.Lyrics.GetAll
{
    public interface ICreateLyricOutputHandler<T>
    {
        T Result();

        void Success(CreateLyricOutput output);

        void BadRequest(string msg);

    }
}
