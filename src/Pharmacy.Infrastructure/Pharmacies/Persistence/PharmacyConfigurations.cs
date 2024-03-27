using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Common.ValueObjects.Name;

namespace Pharmacy.Infrastructure.Pharmacies.Persistence;

public class PharmacyConfigurations : IEntityTypeConfiguration<Domain.PharmacyAggregate.Pharmacy>
{
    public void Configure(EntityTypeBuilder<Domain.PharmacyAggregate.Pharmacy> builder)
    {
        builder.HasKey(ph => ph.Id);

        builder.Property(ph => ph.Id)
            .ValueGeneratedNever();

        // builder.OwnsOne(ph => ph.Address, address =>
        // {
        //     address.Property(a => a.City).HasColumnName("City");
        //     address.Property(a => a.Country).HasColumnName("Country");
        //     address.Property(a => a.Street).HasColumnName("Street");
        //     address.Property(a => a.PostalCode).HasColumnName("PostalCode");
        // });

        builder.ComplexProperty(ph => ph.Address);

        builder.Property(ph => ph.Name)
            .HasConversion(n => n.Value,
                value => Name.Create(value).Value)
            .HasMaxLength(100);
    }
}