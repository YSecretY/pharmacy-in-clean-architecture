using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Common.ValueObjects.Price;
using Pharmacy.Domain.PharmacyAggregate.Entities;
using Pharmacy.Domain.PharmacyAggregate.Enums;

namespace Pharmacy.Infrastructure.Orders.Persistence;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedNever();

        builder.Property(o => o.Status)
            .HasConversion(o => o.Value,
                value => OrderStatus.FromValue(value));

        builder.Property(o => o.TotalPrice)
            .HasConversion(p => p.Value,
                value => Price.Create(value).Value);

        builder.Property(o => o.PharmacyId)
            .IsRequired();

        builder.HasMany(o => o.Products);
        
        builder.Navigation(o => o.Pharmacy);

        builder.HasIndex(o => o.PharmacyId);
    }
}