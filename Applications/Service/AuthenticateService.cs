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

    public async Task<bool> Authenticate(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null)
        {
            return false;
        }

        // Verifique se a senha corresponde (você pode usar hashing de senha aqui)

        return _passwordEncripter.VerifyPassword(user.Password, password);
    }
}
