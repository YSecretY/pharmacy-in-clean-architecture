using ErrorOr;
using PharmacyCleanArchitecture.Domain.Common.Models;
using PharmacyCleanArchitecture.Domain.Common.ValueObjects.Name;

namespace PharmacyCleanArchitecture.Domain.Categories;

public sealed class Category : Entity<Guid>
{
    private Category(Guid id, Name name, string? imageUrl) : base(id)
    {
        Name = name;
        ImageUrl = imageUrl;
    }

    public static ErrorOr<Category> Create(Guid guid, string name, string? imageUrl)
    {
        ErrorOr<Name> nameCreationResult = Name.Create(name);
        if (nameCreationResult.IsError) return nameCreationResult.Errors;

        return new Category(guid, nameCreationResult.Value, imageUrl);
    }

    public Name Name { get; set; }

    public string? ImageUrl { get; set; }
}