using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Entities.City.Entities;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Infrastructure.Cities.Persistence;

public class CityConfigurations : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Name)
            .HasConversion(n => n.Value,
                value => Name.Create(value).Value)
            .HasMaxLength(100);

        builder.Property(c => c.CountryId)
            .IsRequired();

        builder.HasIndex(c => c.CountryId);

        builder
            .HasOne(c => c.Country)
            .WithMany(country => country.Cities)
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(c => c.Country);
    }
}