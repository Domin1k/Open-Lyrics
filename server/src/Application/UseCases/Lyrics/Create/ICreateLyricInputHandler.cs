namespace Application.UseCases.Lyrics.Create
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICreateLyricInputHandler<T>
    {
        Task HandleAsync(CreateLyricInput input, ICreateLyricOutputHandler<T> output);

        Task HandleAsync(IEnumerable<CreateLyricInput> inputs, ICreateLyricOutputHandler<T> output);
    }
}
