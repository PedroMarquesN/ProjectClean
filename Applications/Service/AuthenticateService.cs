using ProjetoClean.Domain.Interfaces;

namespace ProjetoClean.Application.Service;

public class AuthenticateService : IAuthenticate
{
    private readonly IUserRepository _userRepository;

    public AuthenticateService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Authenticate(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null)
        {
            return false;
        }

        // Verifique se a senha corresponde (você pode usar hashing de senha aqui)
        
        return user.Password == password;
    }
}
