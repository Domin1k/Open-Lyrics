namespace Application.UseCases.Lyrics.Create
{
    public class CreateLyricOutput
    {
        public CreateLyricOutput(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
