namespace Pharmacy.Domain.Entities;

public sealed class City
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public Guid CountryId { get; set; }

    public Country? Country { get; set; }
}