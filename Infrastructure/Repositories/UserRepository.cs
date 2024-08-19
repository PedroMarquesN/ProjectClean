using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoClean.Domain.Entities;
using ProjetoClean.Domain.Interfaces;

namespace ProjetoClean.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddUser(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
          
            Console.WriteLine(ex.InnerException?.Message);
            throw;
        }
    }

    public async Task<List<User>> GetAllUsers()
    {

        return await _context.Users.Include(u => u.Profile).ToListAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }


    public async Task<User> GetUserByIdAsync(long id) 
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    public async Task RemoveUser(User user)
    {
        try
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
 
    }
}
