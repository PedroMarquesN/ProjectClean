using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoClean.Domain.Entities;

namespace ProjetoClean.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TesteAPI : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok("Teste API");
    }

}
