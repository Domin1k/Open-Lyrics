namespace Application.UseCases.Lyrics.Create
{
    using System.Threading.Tasks;

    public interface ICreateLyricInputHandler<T>
    {
        Task HandleAsync(CreateLyricInput input, ICreateLyricOutputHandler<T> output);
    }
}
