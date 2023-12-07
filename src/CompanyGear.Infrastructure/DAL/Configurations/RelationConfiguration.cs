using CompanyGear.Core.Entities;
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
    }
}