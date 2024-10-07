using Library.Core.Entities;

namespace Library.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<User> GetByUsernameAsync(string username);
    }
}
