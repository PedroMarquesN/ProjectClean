using ProjetoClean.Application.Dtos.Profile;

namespace ProjetoClean.Application.Interfaces;
public interface IProfileService
{
    Task<ProfileDto> GetProfileById(long userId);
    Task UpdateProfile(long userId,ProfileDto profileDto);
}
