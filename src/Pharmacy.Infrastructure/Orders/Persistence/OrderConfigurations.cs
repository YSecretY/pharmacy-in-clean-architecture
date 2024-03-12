using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Entities.Enums;

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

        builder.Property(o => o.PharmacyId)
            .IsRequired();

        builder.HasMany(o => o.Products);

        builder.Navigation(o => o.Pharmacy);

        builder.Property(o => o.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(o => o.UpdatedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder.HasIndex(o => o.PharmacyId);
    }
}