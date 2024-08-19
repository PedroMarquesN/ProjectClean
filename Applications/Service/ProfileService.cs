using ProjetoClean.Application.Dtos.Profile;
using ProjetoClean.Application.Interfaces;
using ProjetoClean.Domain.Interfaces;

namespace ProjetoClean.Application.Service;

public class ProfileService : IProfileService
{

    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    public async Task<ProfileDto> GetProfileById(long userId)
    {
        try
        {
           var profile = await _profileRepository.GetProfileByIdAsync(userId);
            if (profile == null)
            {
                throw new Exception("Profile not found");
            }
            var profileDto = new ProfileDto
            {
                Name = profile.Name,
                Adress = profile.Adress,
                BitrhDate = profile.BitrhDate,
                Phone = profile.Phone
            };
            return profileDto;
        }
        catch(Exception e)
        { 
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateProfile(long userId, ProfileDto profileDto)
    {
        try 
        {
            var profile = await _profileRepository.GetProfileByIdAsync(userId);

            if(profile !=null)
            {
                profile.Name = profileDto.Name;
                profile.Adress = profileDto.Adress;
                profile.BitrhDate = profileDto.BitrhDate;
                profile.Phone = profileDto.Phone;

                await _profileRepository.UpdateProfile(profile);
            }
            else
            {
                throw new Exception("Profile not found");
            }
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }


}
