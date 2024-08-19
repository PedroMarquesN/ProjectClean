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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração da relação entre User e Profile com restrição de deleção
        modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<User>(u => u.ProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
