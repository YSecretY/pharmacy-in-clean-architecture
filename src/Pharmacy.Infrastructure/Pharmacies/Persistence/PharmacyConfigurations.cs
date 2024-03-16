using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pharmacy.Infrastructure.Pharmacies.Persistence;

public class PharmacyConfigurations : IEntityTypeConfiguration<Domain.Entities.Pharmacy.Entities.Pharmacy>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Pharmacy.Entities.Pharmacy> builder)
    {
        builder.HasKey(ph => ph.Id);

        builder.Property(ph => ph.Id)
            .ValueGeneratedNever();

        builder.Property(ph => ph.Name)
            .HasMaxLength(100);

        builder.Property(ph => ph.CityId)
            .IsRequired();

        builder.Navigation(ph => ph.City);

        builder.HasIndex(ph => ph.CityId);

        builder.Property(ph => ph.CountryId)
            .IsRequired();

        builder.Navigation(ph => ph.Country);

        builder.HasIndex(ph => ph.CountryId);

        builder.HasOne(ph => ph.City)
            .WithMany()
            .HasForeignKey(ph => ph.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ph => ph.Country)
            .WithMany()
            .HasForeignKey(ph => ph.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(ph => ph.Products)
            .WithMany(product => product.Pharmacies);
    }
}