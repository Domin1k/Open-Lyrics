namespace Persistence.Repositories
{
    using Application.Interfaces.Repositories;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LyricEfRepository : ILyricRepository
    {
        private readonly LyricsDbContext _dbContext;

        public LyricEfRepository(LyricsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateAsync(User entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            foreach (var lyrics in entity.Lyrics)
            {
                if (lyrics.Id == default)
                {
                    _dbContext.Entry(entity).State = EntityState.Added;
                }
                else
                {
                    _dbContext.Entry(entity).State = EntityState.Modified;
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Lyric entity)
        {
            _dbContext.Lyrics.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Lyric entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lyric>> GetAllAsync()
            => await _dbContext
                .Lyrics
                .AsNoTracking()
                .ToListAsync();

        public async Task<Lyric> GetAsync(int id)
             => await _dbContext
                .Lyrics
                .AsQueryable()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Lyric entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lyric>> GetAllNonDeletedAsync(int page, int pageSize)
            => await _dbContext
                .Lyrics
                .Skip(page - 1 * (page * pageSize))
                .Take(pageSize)
                .AsNoTracking()
                .Select(x => new Lyric
                {
                    Id = x.Id,
                    Singer = x.Singer,
                    Text = x.Text,
                    Title = x.Title,
                    AuthorId = x.AuthorId,
                    Author = x.Author
                })
                .ToListAsync();

        public async Task<bool> ExistsAsync(int id)
            => await _dbContext
                .Lyrics
                .AnyAsync(x => x.Id == id);

        public async Task CreateManyAsync(IEnumerable<Lyric> entity)
        {
            _dbContext.Lyrics.AddRange(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
