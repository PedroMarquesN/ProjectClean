namespace ProjetoClean.Domain.Security.Cryptography;

public interface IPasswordEncripter
{

    string EncryptPassword(string password);
    bool VerifyPassword(string hashedPassword, string password);
}
