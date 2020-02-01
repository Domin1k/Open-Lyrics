namespace Application.UseCases.Lyrics.GetAll
{
    using System.Threading.Tasks;

    public interface ICreateLyricInputHandler<T>
    {
        Task HandleAsync(CreateLyricInput input, ICreateLyricOutputHandler<T> output);
    }
}
