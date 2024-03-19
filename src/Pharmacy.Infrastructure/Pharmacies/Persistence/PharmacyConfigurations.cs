using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Common.ValueObjects.CountryIsoCode;
using Pharmacy.Domain.Common.ValueObjects.Name;

namespace Pharmacy.Infrastructure.Pharmacies.Persistence;

public class PharmacyConfigurations : IEntityTypeConfiguration<Domain.PharmacyAggregate.Pharmacy>
{
    public void Configure(EntityTypeBuilder<Domain.PharmacyAggregate.Pharmacy> builder)
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
            .HasMany(ph => ph.Users);
        
        builder
            .HasMany(ph => ph.Products)
            .WithMany(product => product.Pharmacies);
    }
}