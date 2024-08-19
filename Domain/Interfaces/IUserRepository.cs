using ProjetoClean.Domain.Entities;

namespace ProjetoClean.Domain.Interfaces;
public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task AddUser(User user);

    Task<User> GetUserByIdAsync(long id);
    Task<List<User>> GetAllUsers();

    Task UpdateUser(User user);
    Task RemoveUser(User user);

}
