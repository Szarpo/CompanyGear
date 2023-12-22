using CompanyGear.Core.Entities;
using CompanyGear.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyGear.Infrastructure.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Login).HasConversion(x => x.Value, x => new Login(x));
        builder.Property(x => x.FullName).HasConversion(x=> x.Value, x => new FullName(x));
        builder.Property(x => x.Password).HasConversion(x => x.Value, x => new Password(x));
        builder.Property(x => x.Role).HasConversion(x=> x.Value, x=> new Role(x));
        builder.Property(x => x.CreatedAt);
    }
}