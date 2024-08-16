using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoClean.Domain.Interfaces;
using ProjetoClean.WebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoClean.WebApi.Controllers;
[Route("api/[controller]")]
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


    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginModel userInfo)
    {
        try
        {
            var result = await _authenticate.Authenticate(userInfo.Email, userInfo.Password);

            if (result)
            {
                var token = GenerateToken(userInfo);
                
                return Ok(token);
                
            }
            else
            {
                return Unauthorized();
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }


    private UserToken GenerateToken(LoginModel userInfo)
    {
        //declarações do usuário
        var claims = new[]
        {
            new Claim("email", userInfo.Email),
            new Claim("meuvalor", "etcetc"),
            new Claim(ClaimTypes.Role, "ADMIN"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };


        //gerar chave privada para assinar o token

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

        //gerar a assinatura digital do token

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        //definir o tempo de expiração
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
            Expiration = expiration
        };
    }


}
