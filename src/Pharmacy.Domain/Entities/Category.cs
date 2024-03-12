namespace Pharmacy.Domain.Entities;

public sealed class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}