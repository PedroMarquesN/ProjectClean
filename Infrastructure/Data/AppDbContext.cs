namespace Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoClean.Domain.Entities;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<PageWeb> PagesWeb { get; set; }

}
