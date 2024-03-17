using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Pharmacy.Entities;
using Pharmacy.Domain.Pharmacy.ValueObjects;

namespace Pharmacy.Infrastructure.Products.Persistence;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Name)
            .HasConversion(n => n.Value,
                value => Name.Create(value).Value)
            .HasMaxLength(100);

        builder.Property(p => p.BrandId)
            .IsRequired();

        builder.Property(p => p.Price)
            .HasConversion(p => p.Value,
                value => Price.Create(value).Value);

        builder.HasOne(p => p.Brand)
            .WithMany()
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(p => p.Brand);

        builder.Property(p => p.CategoryId)
            .IsRequired();

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(p => p.Category);

        builder.Property(p => p.Description)
            .HasMaxLength(500);

        builder.HasMany(p => p.Pharmacies);
    }
}