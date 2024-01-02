using CompanyGear.Core.Entities;
using CompanyGear.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyGear.Infrastructure.DAL.Configurations;

public class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TypeOfDevice).HasConversion(x => x.Value, x => new TypeOfDevice(x));
        builder.Property(x => x.Model).HasConversion(x => x.Value, x => new Model(x));
        builder.Property(x => x.SerialNumber).HasConversion(x => x.Value, x => new SerialNumber(x));
        builder.Property(x => x.UteNumber).HasConversion(x => x.Value, x => new UteNumber(x));
        
    }
}