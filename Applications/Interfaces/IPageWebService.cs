using ProjetoClean.Application.Dtos.PageWeb;

namespace ProjetoClean.Application.Interfaces;

public interface IPageWebService
{
    Task AddPageWeb(RegisterPageWebDto pageWebDto);
    Task<PageWebDto> GetPageWebByIdAsync(long id);
    Task<List<PageWebDto>> GetAllPagesWeb();
    Task UpdatePageWeb(long IdPage,UpdatePageWebDto pageWebDto);
    Task RemovePageWeb(long id);
}
