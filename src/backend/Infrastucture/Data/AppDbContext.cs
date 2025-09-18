using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
        base.OnModelCreating(modelBuilder);
    }
}
