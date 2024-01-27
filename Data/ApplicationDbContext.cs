using Lab4Cities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab4Cities.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Province> Provinces { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // builder.Entity<City>().Property(c => c.CityName).IsRequired();
        // builder.Entity<Province>().Property(p => p.ProvinceName).IsRequired();

        builder.Entity<City>().ToTable("City");
        builder.Entity<Province>().ToTable("Province");

        builder.Seed();
    }
}
