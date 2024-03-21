using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Common.ValueObjects.Name;
using ErrorOr;

namespace Pharmacy.Domain.Category;

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