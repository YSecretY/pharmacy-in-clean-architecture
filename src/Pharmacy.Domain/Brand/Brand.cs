using Pharmacy.Domain.Common.Models;
using ErrorOr;
using Pharmacy.Domain.Common.ValueObjects.Name;

namespace Pharmacy.Domain.Brand;

public sealed class Brand : Entity<Guid>
{
    private Brand(Guid id, Name name, string? logoImageUrl) : base(id)
    {
        Name = name;
        LogoImageUrl = logoImageUrl;
    }

    public static ErrorOr<Brand> Create(Guid guid, string name, string? logoImageUrl)
    {
        ErrorOr<Name> nameCreationResult = Name.Create(name);
        if (nameCreationResult.IsError) return nameCreationResult.Errors;

        return new Brand(guid, nameCreationResult.Value, logoImageUrl);
    }

    public Name Name { get; set; }

    public string? LogoImageUrl { get; set; }
}