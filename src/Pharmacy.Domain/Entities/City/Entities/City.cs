using Pharmacy.Domain.Common.Models;

namespace Pharmacy.Domain.Entities.City.Entities;

public sealed class City : Entity
{
    public City(Guid id, string name, Guid countryId) : base(id)
    {
        Name = name;
        CountryId = countryId;
    }

    public string Name { get; set; }

    public Guid CountryId { get; set; }

    public Country.Entities.Country? Country { get; set; }
}