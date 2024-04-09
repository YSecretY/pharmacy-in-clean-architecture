using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Price;
using PharmacyCleanArchitecture.Domain.OrderAggregate;
using PharmacyCleanArchitecture.Domain.OrderAggregate.Enums;

namespace PharmacyCleanArchitecture.Infrastructure.Orders.Persistence;

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

        builder.Property(o => o.UserId)
            .IsRequired();

        builder.Navigation(o => o.User);

        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(o => o.Pharmacy);

        builder.HasIndex(o => o.PharmacyId);
    }
}