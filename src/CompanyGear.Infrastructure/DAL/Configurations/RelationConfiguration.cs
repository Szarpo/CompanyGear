using CompanyGear.Core.Entities;
using CompanyGear.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyGear.Infrastructure.DAL.Configurations;

public class RelationConfiguration : IEntityTypeConfiguration<Relation>
{
    public void Configure(EntityTypeBuilder<Relation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.EmployeeId);
        builder.Property(x => x.GearId);
        builder.Property(x => x.RelationStatus).HasConversion(x => x.Value, x => new RelationStatus(x));
    }
}