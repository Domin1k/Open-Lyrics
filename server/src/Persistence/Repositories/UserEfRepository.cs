namespace Persistence.Repositories
{
    using Application.Interfaces.Repositories;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserEfRepository : IUserRepository
    {
        private readonly LyricsDbContext _dbContext;

        public UserEfRepository(LyricsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User entity)
        {
            _dbContext.Users.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
            => await _dbContext
                .Users
                .AnyAsync(x => x.Id == id);

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _dbContext
                .Users
                .AsNoTracking()
                .Include(x => x.Lyrics)
                .ToListAsync();

        public async Task<User> GetAsync(int id)
            => await _dbContext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetByUsernameAsync(string username)
             => await _dbContext
                .Users
                .Where(x => x.Username == username)
                .Select(x => new User
                {
                    Id = x.Id,
                    Username = x.Username,
                    PasswordSalt = x.PasswordSalt,
                    PasswordHash = x.PasswordHash
                })
                .FirstOrDefaultAsync();
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
    }
}
