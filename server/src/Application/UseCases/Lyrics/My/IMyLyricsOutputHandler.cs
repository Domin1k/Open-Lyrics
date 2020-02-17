namespace Application.UseCases.Lyrics.My
{
    public interface IMyLyricsOutputHandler<T>
    {
        T Result();

        void Success(MyLyricsOutput output);

        void BadRequest(string msg);
    }
}
