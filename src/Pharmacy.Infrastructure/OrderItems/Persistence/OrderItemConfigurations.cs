using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Common.ValueObjects.Price;
using Pharmacy.Domain.OrderItems;

namespace Pharmacy.Infrastructure.OrderItems.Persistence;

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