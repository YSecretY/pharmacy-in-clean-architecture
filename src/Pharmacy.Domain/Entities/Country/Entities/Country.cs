using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Entities.Enums;

namespace Pharmacy.Domain.Entities.Country.Entities;

public sealed class Country : Entity
{
    public Country(Guid id, string name, Currency currency) : base(id)
    {
        Name = name;
        Currency = currency;
    }

    public string Name { get; set; }

    public Currency Currency { get; set; }

    public List<City.Entities.City> Cities { get; set; } = null!;
}