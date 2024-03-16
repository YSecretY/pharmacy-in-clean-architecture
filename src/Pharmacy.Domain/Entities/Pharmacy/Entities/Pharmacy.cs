using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.Entities.Pharmacy.Entities;

public sealed class Pharmacy : Entity
{
    public Pharmacy(Guid id, string name, Guid cityId, Guid countryId) : base(id)
    {
        Name = name;
        CityId = cityId;
        CountryId = countryId;
    }

    public string Name { get; set; }

    public Guid CityId { get; set; }

    public City.Entities.City? City { get; set; }

    public Guid CountryId { get; set; }

    public Country.Entities.Country? Country { get; set; }

    public List<Product.Entities.Product> Products { get; set; } = null!;
}