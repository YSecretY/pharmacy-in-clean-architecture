using Pharmacy.Domain.Common.Primitives;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.City.Entities;

public sealed class City : Entity
{
    public City(Guid id, Name name, Guid countryId) : base(id)
    {
        Name = name;
        CountryId = countryId;
    }

    public Name Name { get; set; }

    public Guid CountryId { get; set; }

    public Country.Entities.Country? Country { get; set; }
}