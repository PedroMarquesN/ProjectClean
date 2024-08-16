using ProjetoClean.Domain.Entities;

namespace ProjetoClean.Domain.Interfaces;
public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task AddUser(User user);

    Task<List<User>> GetAllUsers();
}
