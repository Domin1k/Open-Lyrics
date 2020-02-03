namespace Application.UseCases.Lyrics.Delete
{
    public interface IDeleteLyricOutputHandler<T>
    {
        T Result();

        void Success(string output);

        void BadRequest(string msg);

    }
}
