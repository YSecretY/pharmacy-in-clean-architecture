using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Price;
using PharmacyCleanArchitecture.Domain.OrderAggregate.Entities;

namespace PharmacyCleanArchitecture.Infrastructure.OrderItems.Persistence;

public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);

        builder.Property(oi => oi.Id)
            .ValueGeneratedNever();

        builder.Navigation(oi => oi.Product);
        
        builder.Property(oi => oi.PricePerUnit)
            .HasConversion(p => p.Value,
                value => Price.Create(value).Value);

        builder.Property(oi => oi.TotalPrice)
            .HasConversion(p => p.Value,
                value => Price.Create(value).Value);

        builder.HasIndex(oi => oi.ProductId);
    }
}