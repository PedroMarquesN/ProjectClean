using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoClean.Application.Dtos.PageWeb;
using ProjetoClean.Application.Interfaces;

namespace ProjetoClean.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PageWebController : ControllerBase
{

    private readonly IPageWebService _pageWebService;

    public PageWebController(IPageWebService pageWebService)
    {
        _pageWebService = pageWebService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPageWeb([FromBody] RegisterPageWebDto pageWebDto)
    {
        try
        {
            await _pageWebService.AddPageWeb(pageWebDto);
            return StatusCode(StatusCodes.Status201Created, "Página cadastrada com sucesso.");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPagesWeb()
    {
        try
        {
            var pagesWeb = await _pageWebService.GetAllPagesWeb();
            return StatusCode(StatusCodes.Status200OK, pagesWeb);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("{pageId}")]
    public async Task<IActionResult> GetPageWebByIdAsync([FromRoute] long pageId)
    {
        try
        {
            var pageWeb = await _pageWebService.GetPageWebByIdAsync(pageId);
            return StatusCode(StatusCodes.Status200OK, pageWeb);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("{pageId}")]
    public async Task<IActionResult> RemovePageWeb([FromRoute] long pageId)
    {
        try
        {
            await _pageWebService.RemovePageWeb(pageId);
            return StatusCode(StatusCodes.Status200OK, "Página removida com sucesso.");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPut("{pageId}")]
    public async Task<IActionResult> UpdatePageWeb([FromRoute] long pageId, [FromBody] UpdatePageWebDto pageWebDto)
    {
        try
        {
            await _pageWebService.UpdatePageWeb(pageId, pageWebDto);
            return StatusCode(StatusCodes.Status200OK, "Página atualizada com sucesso.");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}
