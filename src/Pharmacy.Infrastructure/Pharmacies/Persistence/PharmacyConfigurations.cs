using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities.Pharmacy.ValueObjects;

namespace Pharmacy.Infrastructure.Pharmacies.Persistence;

public class PharmacyConfigurations : IEntityTypeConfiguration<Domain.Entities.Pharmacy.Pharmacy>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Pharmacy.Pharmacy> builder)
    {
        builder.HasKey(ph => ph.Id);

        builder.Property(ph => ph.Id)
            .ValueGeneratedNever();

        builder.Property(ph => ph.CountryIsoCode)
            .IsRequired()
            .HasConversion(c => c.Value,
                value => CountryIsoCode.Create(value).Value);

        builder.Property(ph => ph.Name)
            .HasConversion(n => n.Value,
                value => Name.Create(value).Value)
            .HasMaxLength(100);

        builder
            .HasMany(ph => ph.Products)
            .WithMany(product => product.Pharmacies);
    }
}