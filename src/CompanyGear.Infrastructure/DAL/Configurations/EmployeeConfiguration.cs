using CompanyGear.Core.Entities;
using CompanyGear.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyGear.Infrastructure.DAL.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.EmployeeId);
        builder.Property(x => x.FirstName).HasConversion(x => x.Value, x => new FirstName(x));
        builder.Property(x => x.LastName).HasConversion(x => x.Value, x => new LastName(x));
        builder.Property(x => x.EmployeeNumber).HasConversion(x => x.Value, x => new EmployeeNumber(x));
        builder.Property(x => x.Department).HasConversion(x => x.Value, x => new Department(x));
    }
}