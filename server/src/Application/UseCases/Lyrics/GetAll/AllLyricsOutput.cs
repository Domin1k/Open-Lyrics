﻿namespace Application.UseCases.Lyrics.GetAll
{
    public class AllLyricsOutput
    {
        public AllLyricsOutput(int id, string text, string title, string singer, int authorId, string authorName)
        {
            Id = id;
            Text = text;
            Title = title;
            Singer = singer;
            AuthorId = authorId;
            AuthorName = authorName;
        }

        public int Id { get; }

        public string Text { get; }

        public string Title { get; }

        public string Singer { get; }

        public int AuthorId { get; }

        public string AuthorName { get; }
    }
}
