namespace Application.UseCases.Lyrics.My
{
    using System.Threading.Tasks;

    public interface IMyLyricsInputHandler<T>
    {
        Task HandleAsync(MyLyricsInput input, IMyLyricsOutputHandler<T> output);
    }
}
