namespace WebAPI.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Persistence;

    public class LyricDbContextFactory : IDesignTimeDbContextFactory<LyricsDbContext>
    {
        public LyricsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LyricsDbContext>();
            builder.UseSqlServer("server=(LocalDb)\\MSSQLLocalDB; database=LyricsDB; Integrated Security=true");
            return new LyricsDbContext(builder.Options);
        }
    }
}
