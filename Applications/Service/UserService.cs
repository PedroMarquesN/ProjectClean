using ProjetoClean.Application.Dtos.User;
using ProjetoClean.Application.Interfaces;
using ProjetoClean.Domain.Entities;
using ProjetoClean.Domain.Interfaces;
using ProjetoClean.Domain.Security.Cryptography;

namespace ProjetoClean.Application.Service;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncripter _passwordEncripter;

    public UserService(IUserRepository userRepository , IPasswordEncripter passwordEncripter)
    {
        _userRepository = userRepository;
        _passwordEncripter = passwordEncripter;
    }

    public async Task<List<UserDto>> GetAllUsers()
    {
       var users = await _userRepository.GetAllUsers();


        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            Role = u.Role.ToString()
        }).ToList();


    }

    public async Task RegisterUser(RegisterUserDto userDto)
    {
        try
        {
            var user = new User(userDto.Email, _passwordEncripter.EncryptPassword(userDto.Password));
            await _userRepository.AddUser(user);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}


