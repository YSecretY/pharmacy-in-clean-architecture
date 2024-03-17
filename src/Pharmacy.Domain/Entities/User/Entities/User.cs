using Pharmacy.Domain.Common.Primitives;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.User.Entities;

public class User : Entity<Guid>
{
    public User(
        Guid id,
        string email,
        string normalizedEmail,
        FirstName? firstName,
        bool emailConfirmed,
        string passwordHash,
        string? phoneNumber,
        bool isAdmin,
        Guid cityId,
        Guid countryId) : base(id)
    {
        Email = email;
        NormalizedEmail = normalizedEmail;
        FirstName = firstName;
        EmailConfirmed = emailConfirmed;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        IsAdmin = isAdmin;
        CityId = cityId;
        CountryId = countryId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public string Email { get; set; }

    public string NormalizedEmail { get; set; }

    public FirstName? FirstName { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PasswordHash { get; set; }

    public string? PhoneNumber { get; set; }

    public bool IsAdmin { get; set; }

    public Guid CityId { get; set; }

    public City.Entities.City? City { get; set; }

    public Guid CountryId { get; set; }

    public Country.Entities.Country? Country { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}