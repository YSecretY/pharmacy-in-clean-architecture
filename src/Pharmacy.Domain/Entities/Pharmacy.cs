namespace Pharmacy.Domain.Entities;

public sealed class Pharmacy
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid CityId { get; set; }

    public City? City { get; set; }

    public Guid CountryId { get; set; }

    public Country? Country { get; set; }

    public List<Product> Products { get; set; } = null!;
}