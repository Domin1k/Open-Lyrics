namespace Application.UseCases.Lyrics.Edit
{
    using System.Threading.Tasks;

    public interface IEditLyricInputHandler<T>
    {
        Task HandleAsync(EditLyricInput input, IEditLyricOutputHandler<T> output);
    }
}
