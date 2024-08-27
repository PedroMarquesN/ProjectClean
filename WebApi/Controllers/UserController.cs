using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoClean.Application.Dtos.User;
using ProjetoClean.Application.Interfaces;
using ProjetoClean.Domain.Interfaces;
namespace ProjetoClean.WebApi.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

    public UserController(IUserRepository userRepository, IUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto userDto)
    {
        try
        {
            await _userService.RegisterUser(userDto);
            return StatusCode(StatusCodes.Status201Created, "Usuário cadastrado com sucesso.");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await _userService.GetAllUsers();
            return StatusCode(StatusCodes.Status200OK, users);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("/delete/{userId}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> RemoveUser([FromRoute] long userId)
    {
        try
        {
            await _userService.RemoveUser(userId);
            return StatusCode(StatusCodes.Status200OK, "Usuário removido com sucesso.");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }



}