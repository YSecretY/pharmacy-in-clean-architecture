using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities.User;
using Pharmacy.Domain.Entities.User.ValueObjects;

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

        builder.Property(u => u.PhoneNumber)
            .HasConversion(ph => ph!.Value,
                value => PhoneNumber.Create(value).Value)
            .HasMaxLength(100);
    }
}