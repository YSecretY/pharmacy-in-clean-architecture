using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.User;
using Pharmacy.Domain.User.Enums;
using Pharmacy.Domain.User.ValueObjects;

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
            .HasConversion(e => e.Value,
                value => Email.Create(value).Value)
            .HasMaxLength(255);

        builder.Property(u => u.PasswordHash)
            .HasConversion(p => p.Value,
                value => PasswordHash.Create(value).Value)
            .HasMaxLength(500);

        builder.Property(u => u.Role)
            .HasConversion(r => r.Value,
                value => UserRole.FromValue(value));

        builder.Property(u => u.PhoneNumber)
            .HasConversion(ph => ph!.Value,
                value => PhoneNumber.Create(value).Value)
            .HasMaxLength(100);
    }
}