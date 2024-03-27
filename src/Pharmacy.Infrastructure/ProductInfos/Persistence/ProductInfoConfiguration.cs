using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Common.ValueObjects.Price;
using Pharmacy.Domain.PharmacyAggregate.Entities;

namespace Pharmacy.Infrastructure.ProductInfos.Persistence;

public class ProductInfoConfiguration : IEntityTypeConfiguration<ProductInfo>
{
    public void Configure(EntityTypeBuilder<ProductInfo> builder)
    {
        builder.HasKey(info => info.Id);

        builder.Property(info => info.Id)
            .ValueGeneratedNever();

        builder.Property(info => info.DiscountedPrice)
            .HasConversion(price => price.Value,
                value => Price.Create(value).Value);

        builder.Navigation(info => info.Pharmacy);
        builder.Navigation(info => info.Product);

        builder.HasIndex(info => info.PharmacyId);
        builder.HasIndex(info => info.ProductId);
    }
}