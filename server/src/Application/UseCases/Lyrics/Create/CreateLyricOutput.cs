namespace Application.UseCases.Lyrics.GetAll
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
