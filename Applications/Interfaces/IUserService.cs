using ProjetoClean.Application.Dtos.User;

namespace ProjetoClean.Application.Interfaces;

public interface IUserService
{
    Task RegisterUser(RegisterUserDto userDto);
    Task<List<UserDto>> GetAllUsers();
}
