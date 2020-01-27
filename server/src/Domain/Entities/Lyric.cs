namespace Domain.Entities
{
    using Domain.Exceptions;

    public class Lyric : Entity<int>
    {
        public Lyric(string text, string title, string singer, int authorId, User author)
        {
            Text = text ?? throw new DomainException($"Parameter - {nameof(text)} cannot be null!");
            Title = title ?? throw new DomainException($"Parameter - {nameof(title)} cannot be null!");
            Singer = singer ?? throw new DomainException($"Parameter - {nameof(singer)} cannot be null!");
            AuthorId = authorId;
            Author = author;
        }

        public string Text { get; set; }

        public string Title { get; set; }

        public string Singer { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }
    }
}
