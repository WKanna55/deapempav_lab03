using Lab03_WillianKana.Entities;

namespace Lab03_WillianKana.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByUser(string user);
    bool IsAvailableUser(string user);
    Task<User> Update(User userParams, string password = null);
}