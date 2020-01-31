namespace Persistence
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class LyricsDbContext : DbContext
    {
        public const string ConnectionName = "DefaultConnection";

        public LyricsDbContext(DbContextOptions<LyricsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lyric> Lyrics { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lyric>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Lyrics)
                .HasForeignKey(x => x.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
