﻿namespace Application.UseCases.Lyrics.Details
{
    public class DetailsLyricsOutput
    {
        public DetailsLyricsOutput(int id, string text, string title, string singer, int authorId, string authorName)
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
