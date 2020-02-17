namespace WebAPI.Features.Lyric.Models
{
    public class MyLyricsRequest
    {
        private const int DefaultPageSize = 10;

        public bool IncludeCount { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; } = DefaultPageSize;
    }
}
