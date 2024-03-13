namespace Pharmacy.Domain.Entities;

public sealed class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public Guid BrandId { get; set; }

    public Brand? Brand { get; set; }

    public Guid CategoryId { get; set; }

    public Category? Category { get; set; }

    public decimal Price { get; set; }

    public Guid CountryId { get; set; }

    public Country? Country { get; set; }

    public string? Description { get; set; }

    public List<Pharmacy> Pharmacies { get; set; } = null!;

    public Guid? OrderId { get; set; }

    public Order? Order { get; set; }
}