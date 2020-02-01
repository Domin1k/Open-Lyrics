namespace Application.Interfaces.Repositories
{
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILyricRepository : IRepository<int, Lyric>
    {
        Task<IEnumerable<Lyric>> GetAllNonDeletedAsync(int page, int pageSize);
    }
}
