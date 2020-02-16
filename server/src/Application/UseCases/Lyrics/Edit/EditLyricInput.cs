namespace Application.UseCases.Lyrics.Edit
{
    public class EditLyricInput
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public string Singer { get; set; }

        public string AuthorUsername { get; set; }
    }
}
