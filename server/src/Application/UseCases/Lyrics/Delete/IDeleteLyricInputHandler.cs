namespace Application.UseCases.Lyrics.Delete
{
    using System.Threading.Tasks;

    public interface IDeleteLyricInputHandler<T>
    {
        Task HandleAsync(DeleteLyricInput input, IDeleteLyricOutputHandler<T> output);
    }
}
