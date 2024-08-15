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

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

}
