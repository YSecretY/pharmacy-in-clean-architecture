using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities.Brand.Entities;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Infrastructure.Brands.Persistence;

public class BrandConfigurations : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedNever();

        builder.Property(b => b.Name)
            .HasConversion(n => n.Value,
                value => Name.Create(value).Value)
            .HasMaxLength(100);
    }
}