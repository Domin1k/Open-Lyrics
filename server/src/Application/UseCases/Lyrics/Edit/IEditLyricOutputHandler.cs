namespace Application.UseCases.Lyrics.Edit
{
    public interface IEditLyricOutputHandler<T>
    {
        T Result();

        void Success(EditLyricOutput output);

        void BadRequest(string msg);
    }
}
