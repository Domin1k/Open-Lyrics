namespace Application.UseCases.Lyrics.CanManage
{
    public interface ICanManageLyricOutputHandler<T>
    {
        T Result();

        void Success(CanManageLyricOutput output);

        void BadRequest(string msg);
    }
}
