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
    private readonly IProfileRepository _profileRepository;
    public UserService(IUserRepository userRepository , IPasswordEncripter passwordEncripter, IProfileRepository profileRepository)
    {
        _userRepository = userRepository;
        _passwordEncripter = passwordEncripter;
        _profileRepository = profileRepository;
    }

    public async Task<List<UserDto>> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsers();

        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Name = u.Profile?.Name ?? string.Empty,
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

            var profile = new Profile
            {
                UserId = user.Id,
                Name = string.Empty,
                BitrhDate = string.Empty,
                Phone = string.Empty,
                Adress = string.Empty
            };
            await _profileRepository.AddProfile(profile);
            user.Profile = profile;
            await _userRepository.UpdateUser(user);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task RemoveUser(long userId)
    {
        try
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user != null)
            {
                await _userRepository.RemoveUser(user);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}


