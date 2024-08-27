using ProjetoClean.Domain.Entities;
using ProjetoClean.Domain.Interfaces;
using ProjetoClean.Domain.Security.Cryptography;

namespace ProjetoClean.Application.Service;

public class AuthenticateService : IAuthenticate
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncripter _passwordEncripter;

    public AuthenticateService(IUserRepository userRepository, IPasswordEncripter passwordEncripter)
    {
        _userRepository = userRepository;
        _passwordEncripter = passwordEncripter;
    }

    public async Task<User> Authenticate(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null || !_passwordEncripter.VerifyPassword(user.Password, password))
        {
            return null;
        }

        return user; // Retorna o objeto User se a autenticação for bem-sucedida
    }
}
