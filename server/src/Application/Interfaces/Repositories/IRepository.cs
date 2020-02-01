namespace Application.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<TKey, TEntity>
    {
        Task<TEntity> GetAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<bool> ExistsAsync(TKey id);
    }
}
