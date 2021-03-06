﻿namespace Domain.Entities
{
    public class Lyric : Entity<int>
    {
        public string Text { get; set; }

        public string Title { get; set; }

        public string Singer { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }
    }
}
