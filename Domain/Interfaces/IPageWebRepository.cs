using ProjetoClean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClean.Domain.Interfaces;
public interface IPageWebRepository
{
    Task AddPageWeb(PageWeb pageWeb);
    Task<PageWeb> GetPageWebByIdAsync(long id);
    Task<List<PageWeb>> GetAllPagesWeb();
    Task UpdatePageWeb(PageWeb pageWeb);
    Task RemovePageWeb(PageWeb pageWeb);
}
