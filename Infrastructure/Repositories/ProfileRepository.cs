using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoClean.Application.Dtos.Profile;
using ProjetoClean.Domain.Entities;
using ProjetoClean.Domain.Interfaces;

namespace ProjetoClean.Infrastructure.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly AppDbContext _context;

    public ProfileRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Profile> AddProfile(Profile profile)
    {
        _context.Profiles.Add(profile);
        await _context.SaveChangesAsync();

        
        return profile;
    }

    public async Task<Profile> GetProfileByIdAsync(long userId)
    {
        return await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public async Task UpdateProfile(Profile profile)
    {
        _context.Profiles.Update(profile);
        await _context.SaveChangesAsync();
    }
}
