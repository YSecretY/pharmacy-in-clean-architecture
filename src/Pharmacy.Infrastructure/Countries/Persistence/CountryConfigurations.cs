using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Entities.Country.Entities;
using Pharmacy.Domain.Entities.Enums;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Infrastructure.Countries.Persistence;

public class CountryConfigurations : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Currency)
            .HasConversion(
                currency => currency.Value,
                value => Currency.FromValue(value));

        builder.HasMany(c => c.Cities)
            .WithOne(city => city.Country)
            .HasForeignKey(city => city.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(c => c.Name)
            .HasConversion(n => n.Value,
                value => Name.Create(value).Value)
            .HasMaxLength(100);
    }
}