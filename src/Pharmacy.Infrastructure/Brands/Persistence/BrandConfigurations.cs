using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Entities.Brand.Entities;

namespace Pharmacy.Infrastructure.Brands.Persistence;

public class BrandConfigurations : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedNever();

        builder.Property(b => b.Name)
            .HasMaxLength(100);
    }
}