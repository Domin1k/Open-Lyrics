namespace Persistence.Repositories
{
    using Application.Interfaces.Repositories;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
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
    }
}
