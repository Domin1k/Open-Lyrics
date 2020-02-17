namespace Application.UseCases.Lyrics.My
{
    using System.Collections.Generic;

    public class MyLyricsOutput
    {
        public MyLyricsOutput(IEnumerable<MyLyricOutput> lyrics, int total = 0)
        {
            Total = total;
            Lyrics = lyrics;
        }

        public int Total { get; }

        public IEnumerable<MyLyricOutput> Lyrics { get; }
    }
}
