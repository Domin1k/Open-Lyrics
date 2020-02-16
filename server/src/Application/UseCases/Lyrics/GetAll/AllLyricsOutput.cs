namespace Application.UseCases.Lyrics.GetAll
{
    using System.Collections.Generic;

    public class AllLyricsOutput
    {
        public AllLyricsOutput(IEnumerable<AllLyricOutput> lyrics, int total = 0)
        {
            Total = total;
            Lyrics = lyrics;
        }

        public int Total { get; }

        public IEnumerable<AllLyricOutput> Lyrics { get; }
    }
}
