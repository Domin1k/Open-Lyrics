namespace Application.UseCases.Lyrics.Details
{
    using System.Threading.Tasks;

    public interface IDetailsLyricsInputHandler<T>
    {
        Task HandleAsync(DetailsLyricsInput input, IDetailsLyricsOutputHandler<T> output);
    }
}
