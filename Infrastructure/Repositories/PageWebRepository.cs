using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoClean.Domain.Entities;
using ProjetoClean.Domain.Interfaces;

namespace ProjetoClean.Infrastructure.Repositories;

public class PageWebRepository : IPageWebRepository
{
    private readonly AppDbContext _context;

    public PageWebRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task AddPageWeb(PageWeb pageWeb)
    {
       try
        {
            await _context.PagesWeb.AddAsync(pageWeb);
            await _context.SaveChangesAsync();
        }
        catch(Exception e)
        {
            
            throw new Exception(e.Message);
        }
    }

    public async Task<List<PageWeb>> GetAllPagesWeb()
    {
        try
        {
            return await _context.PagesWeb.ToListAsync();
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<PageWeb> GetPageWebByIdAsync(long id)
    {
        try
        {
            return await _context.PagesWeb.FindAsync(id);
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task RemovePageWeb(PageWeb pageWeb)
    {
        try
        {
            _context.PagesWeb.Remove(pageWeb);
            await _context.SaveChangesAsync();

        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdatePageWeb(PageWeb pageWeb)
    {
        try
        {
            _context.PagesWeb.Update(pageWeb);
            await _context.SaveChangesAsync();
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
