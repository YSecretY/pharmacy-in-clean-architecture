using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Infrastructure.Pharmacies.Persistence;

public class PharmacyConfigurations : IEntityTypeConfiguration<Domain.Entities.Pharmacy.Entities.Pharmacy>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Pharmacy.Entities.Pharmacy> builder)
    {
        builder.HasKey(ph => ph.Id);

        builder.Property(ph => ph.Id)
            .ValueGeneratedNever();

        builder.Property(ph => ph.Name)
            .HasConversion(n => n.Value,
                value => Name.Create(value).Value)
            .HasMaxLength(100);

        builder
            .HasMany(ph => ph.Products)
            .WithMany(product => product.Pharmacies);
    }
}