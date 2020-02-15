namespace Application.Interfaces.Repositories
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface ILyricRepository : IRepository<int, Lyric>
    {
        Task<IEnumerable<Lyric>> GetAllNonDeletedAsync(int page, int pageSize);
        Task<IEnumerable<Lyric>> GetAllQueryAsync(Expression<Func<Lyric, bool>> query, int page, int pageSize);
    }
}
