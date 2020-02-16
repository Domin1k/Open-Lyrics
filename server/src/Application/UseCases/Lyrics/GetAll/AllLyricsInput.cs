namespace Application.UseCases.Lyrics.GetAll
{
    public class AllLyricsInput
    {
        public string SearchTerm { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public bool IncludeCount { get; set; }
    }
}
