namespace Application.Interfaces.Repositories
{
    using Domain.Entities;

    public interface IUserRepository : IRepository<int, User>
    {
    }
}
