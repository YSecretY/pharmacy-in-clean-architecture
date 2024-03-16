using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities.User.Entities;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Infrastructure.Users.Persistence;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever();

        builder.Property(u => u.FirstName)
            .HasConversion(f => f!.Value,
                value => FirstName.Create(value).Value)
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.NormalizedEmail)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(u => u.NormalizedEmail);

        builder.Property(u => u.PasswordHash)
            .HasMaxLength(500);

        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(100);

        builder.HasOne(u => u.City)
            .WithMany()
            .HasForeignKey(u => u.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(u => u.City);

        builder.HasOne(u => u.Country)
            .WithMany()
            .HasForeignKey(u => u.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(u => u.Country);

        builder.HasIndex(u => new { u.CountryId, u.CityId });
    }
}