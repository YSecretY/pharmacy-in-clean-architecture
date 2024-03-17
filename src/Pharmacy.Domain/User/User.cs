using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.User.ValueObjects;

namespace Pharmacy.Domain.User;

public class User : Entity<Guid>
{
    public User(
        Guid id,
        Email email,
        FirstName? firstName,
        bool emailConfirmed,
        PasswordHash passwordHash,
        PhoneNumber? phoneNumber,
        bool isAdmin) : base(id)
    {
        Email = email;
        FirstName = firstName;
        EmailConfirmed = emailConfirmed;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        IsAdmin = isAdmin;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Email Email { get; set; }

    public FirstName? FirstName { get; set; }

    public bool EmailConfirmed { get; set; }

    public PasswordHash PasswordHash { get; set; }

    public PhoneNumber? PhoneNumber { get; set; }

    public bool IsAdmin { get; set; }

    public string? CountryIsoCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}