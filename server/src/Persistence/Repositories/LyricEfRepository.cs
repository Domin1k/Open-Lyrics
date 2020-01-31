namespace Persistence.Repositories
{
    using Application.Interfaces.Repositories;
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LyricEfRepository : ILyricRepository
    {
        public Task CreateAsync(Lyric entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Lyric entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lyric>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Lyric> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Lyric entity)
        {
            throw new NotImplementedException();
        }
    }
}
