using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Price;
using PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities;

namespace PharmacyCleanArchitecture.Infrastructure.ProductInfos.Persistence;

public class ProductInfoConfiguration : IEntityTypeConfiguration<ProductInfo>
{
    public void Configure(EntityTypeBuilder<ProductInfo> builder)
    {
        builder.HasKey(info => info.Id);

        builder.Property(info => info.Id)
            .ValueGeneratedNever();

        builder.Property(info => info.DiscountedPrice)
            .HasConversion(price => price != null ? price.Value : (decimal?)null,
                value => Price.Create(value).Value);

        builder.HasOne(info => info.Product);
        builder.HasOne(info => info.Pharmacy);

        builder.Navigation(info => info.Pharmacy);
        builder.Navigation(info => info.Product);

        builder.HasIndex(info => info.PharmacyId);
        builder.HasIndex(info => info.ProductId);
    }
}