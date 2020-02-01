namespace Application.UseCases.Lyrics.GetAll
{
    using System.Threading.Tasks;

    public interface IAllLyricsInputHandler<T>
    {
        Task HandleAsync(AllLyricsInput input, IAllLyricsOutputHandler<T> output);
    }
}
