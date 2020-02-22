namespace Application.UseCases.Lyrics.CanManage
{
    using System.Threading.Tasks;

    public interface ICanManageLyricInputHandler<T>
    {
        Task HandleAsync(CanManageLyricInput input, ICanManageLyricOutputHandler<T> output);
    }
}
