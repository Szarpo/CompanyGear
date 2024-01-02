using CompanyGear.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL;

internal sealed class CompanyDeviceDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set;  }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Relation> Relations { get; set; }
    public DbSet<User> Users { get; set; }

    public CompanyDeviceDbContext(DbContextOptions<CompanyDeviceDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

}