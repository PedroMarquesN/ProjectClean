using ProjetoClean.Domain.Entities;

namespace ProjetoClean.Domain.Interfaces;

public interface IProfileRepository
{
    Task<Profile> GetProfileByIdAsync(long userId);
    Task<Profile> AddProfile(Profile profile);
    Task UpdateProfile(Profile profile);
}
