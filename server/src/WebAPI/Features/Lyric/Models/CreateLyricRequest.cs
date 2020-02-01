namespace WebAPI.Features.Lyric.Models
{
    public class CreateLyricRequest
    {
        public string Text { get; set; }

        public string Title { get; set; }

        public string Singer { get; set; }

        public int AuthorId { get; set; }
    }
}
