namespace Application.Interfaces.Repositories
{
    using Domain.Entities;
    using System.Threading.Tasks;

    public interface IUserRepository : IRepository<int, User>
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
