using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.PharmacyAggregate.ValueObjects;
using ErrorOr;

namespace Pharmacy.Domain.Brand;

public sealed class Brand : Entity<Guid>
{
    private Brand(Guid id, Name name, string? logoImageUrl) : base(id)
    {
        Name = name;
        LogoImageUrl = logoImageUrl;
    }

    public static ErrorOr<Brand> Create(string name, string? logoImageUrl) =>
        new Brand(Guid.NewGuid(), Name.Create(name).Value, logoImageUrl);

    public Name Name { get; set; }

    public string? LogoImageUrl { get; set; }
}