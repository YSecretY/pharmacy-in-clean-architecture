using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Name;

namespace PharmacyCleanArchitecture.Infrastructure.Pharmacies.Persistence;

public class PharmacyConfigurations : IEntityTypeConfiguration<Domain.PharmacyAggregate.Pharmacy>
{
    public void Configure(EntityTypeBuilder<Domain.PharmacyAggregate.Pharmacy> builder)
    {
        builder.HasKey(ph => ph.Id);

        builder.Property(ph => ph.Id)
            .ValueGeneratedNever();

        builder.ComplexProperty(ph => ph.Address);
        
        builder.Property(ph => ph.Name)
            .HasConversion(n => n.Value,
                value => Name.Create(value).Value)
            .HasMaxLength(100);
    }
}