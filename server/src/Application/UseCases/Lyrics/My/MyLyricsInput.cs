namespace Application.UseCases.Lyrics.My
{
    public class MyLyricsInput
    {
        public string AuthorUsername { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public bool IncludeCount { get; set; }
    }
}
