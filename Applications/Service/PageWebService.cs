using ProjetoClean.Application.Dtos.PageWeb;
using ProjetoClean.Application.Interfaces;
using ProjetoClean.Domain.Entities;
using ProjetoClean.Domain.Interfaces;

namespace ProjetoClean.Application.Service;

public class PageWebService : IPageWebService
{

    private readonly IPageWebRepository _pageWebRepository;

    public PageWebService(IPageWebRepository pageWebRepository)
    {
        _pageWebRepository = pageWebRepository;
    }


    public async Task AddPageWeb(RegisterPageWebDto pageWebDto)
    {
        var pageWeb = new PageWeb( pageWebDto.Description, pageWebDto.URL);

        try
        {
            await _pageWebRepository.AddPageWeb(pageWeb);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<PageWebDto>> GetAllPagesWeb()
    {
        var pagesWeb = await _pageWebRepository.GetAllPagesWeb();
        
        return pagesWeb.Select(pageWeb => new PageWebDto
        {
            Id = pageWeb.Id,
            Description = pageWeb.description,
            URL = pageWeb.URL
        }).ToList();
    }

    public async Task<PageWebDto> GetPageWebByIdAsync(long id)
    {
       var pageWeb = await _pageWebRepository.GetPageWebByIdAsync(id);

        if (pageWeb == null)
        {
            throw new Exception("PageWeb not found");
        }

        return new PageWebDto
        {
            Id = pageWeb.Id,
            Description = pageWeb.description,
            URL = pageWeb.URL
        };
    }

    public async Task RemovePageWeb(long id)
    {
      var pageWeb = await _pageWebRepository.GetPageWebByIdAsync(id);

        if (pageWeb == null)
        {
            throw new Exception("PageWeb not found");
        }

        try
        {
            await _pageWebRepository.RemovePageWeb(pageWeb);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdatePageWeb(long IdPage, UpdatePageWebDto pageWebDto)
    {
        try
        {

            var pageWeb = await _pageWebRepository.GetPageWebByIdAsync(IdPage);

            if (pageWeb == null)
            {
                throw new Exception("PageWeb not found");
            }

            pageWeb.description = pageWebDto.Description;
            pageWeb.URL = pageWebDto.URL;

           
            await _pageWebRepository.UpdatePageWeb(pageWeb);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
