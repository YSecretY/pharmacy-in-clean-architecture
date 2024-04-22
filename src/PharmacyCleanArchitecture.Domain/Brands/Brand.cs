using ErrorOr;
using PharmacyCleanArchitecture.Domain.Common.Models;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Name;

namespace PharmacyCleanArchitecture.Domain.Brands;

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