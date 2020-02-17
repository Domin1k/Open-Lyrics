namespace Persistence.Repositories
{
    using Application.Interfaces.Repositories;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class LyricEfRepository : ILyricRepository
    {
        private readonly LyricsDbContext _dbContext;

        public LyricEfRepository(LyricsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountAsync(Expression<Func<Lyric, bool>> query = null)
            => query == null
                ? await _dbContext.Lyrics.Include(x => x.Author).CountAsync()
                : await _dbContext.Lyrics.Include(x => x.Author).CountAsync(query);

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
                .Select(x => new Lyric
                {
                    Id = x.Id,
                    Singer = x.Singer,
                    Text = x.Text,
                    Title = x.Title,
                    AuthorId = x.AuthorId,
                    Author = x.Author
                })
                .AsNoTracking()
                .ToListAsync();

        public async Task<Lyric> GetAsync(int id)
             => await _dbContext
                .Lyrics
               // .AsQueryable()
                //.AsNoTracking()
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Lyric entity)
        {
          //  _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lyric>> GetAllNonDeletedAsync(int page, int pageSize)
            => await _dbContext
                .Lyrics
                .OrderByDescending(x => x.CreatedOn)
                .Skip(pageSize * (page))
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

        public async Task<IEnumerable<Lyric>> GetAllQueryAsync(Expression<Func<Lyric, bool>> query, int page, int pageSize)
            => await _dbContext
                .Lyrics
                .Include(x => x.Author)
                .Where(query)
                .Skip(pageSize * (page))
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
    }
}
