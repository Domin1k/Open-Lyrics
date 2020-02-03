namespace Application.UseCases.Lyrics.Create
{
    public interface ICreateLyricOutputHandler<T>
    {
        T Result();

        void Success(CreateLyricOutput output);

        void BadRequest(string msg);

    }
}
