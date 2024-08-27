using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoClean.Application.Dtos.Profile;
using ProjetoClean.Application.Interfaces;

namespace ProjetoClean.WebApi.Controllers;

[Authorize]
[Route("api/profile")]
[ApiController]
public class ProfileController : ControllerBase
{

    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }


    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateProfile([FromRoute] long userId, [FromBody] ProfileDto profileDto)
    {
        try
        {
            await _profileService.UpdateProfile(userId, profileDto);
            return StatusCode(StatusCodes.Status200OK, "Perfil atualizado com sucesso.");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("getprofile/{userId}")]
    public async Task <IActionResult> GetProfile([FromRoute] long userId)
    {
        try
        {
            var profile = await _profileService.GetProfileById(userId);
            return StatusCode(StatusCodes.Status200OK, profile);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

}
