namespace Application.UseCases.Lyrics.Edit
{
    public class EditLyricOutput
    {
        public EditLyricOutput(int id, string text, string title, string singer)
        {
            Id = id;
            Text = text;
            Title = title;
            Singer = singer;
        }

        public int Id { get; }

        public string Text { get; }

        public string Title { get; }

        public string Singer { get; }
    }
}
