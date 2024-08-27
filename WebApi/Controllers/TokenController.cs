using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjetoClean.Domain.Entities;
using ProjetoClean.Domain.Interfaces;
using ProjetoClean.WebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoClean.WebApi.Controllers;
[Route("api/auth")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticate _authenticate;
    private readonly IConfiguration _configuration;

    public TokenController(IAuthenticate authenticate, IConfiguration configuration)
    {
        _authenticate = authenticate;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel userInfo)
    {
        try
        {
            var user = await _authenticate.Authenticate(userInfo.Email, userInfo.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Passe o objeto `User` ao invés de `userId` e `userInfo`
            var token = GenerateToken(user);

            return Ok(token);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    private UserToken GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim("email", user.Email), // Use o email do objeto `User`
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Id do usuário autenticado
            new Claim(ClaimTypes.Role, user.Role.ToString()), // Role do usuário autenticado
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        // Defina o tempo de expiração
        var expiration = DateTime.UtcNow.AddMinutes(10);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new UserToken()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration,
            UserId = user.Id.ToString(), // Adicionado
            Role = user.Role.ToString()  // Adicionado
        };
    }
}
