namespace WebAPI.Features.Lyric.Models
{
    public class AllLyricsRequest
    {
        private const int DefaultPageSize = 10;

        public string SearchTerm { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; } = DefaultPageSize;
    }
}
