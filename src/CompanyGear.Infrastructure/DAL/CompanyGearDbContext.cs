using CompanyGear.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL;

internal sealed class CompanyGearDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set;  }
    public DbSet<Gear> Gears { get; set; }
    public DbSet<Relation> Relations { get; set; }

    public CompanyGearDbContext(DbContextOptions<CompanyGearDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

}