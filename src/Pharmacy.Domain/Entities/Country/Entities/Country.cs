using Pharmacy.Domain.Common.Primitives;
using Pharmacy.Domain.Entities.Enums;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.Country.Entities;

public sealed class Country : Entity<Guid>
{
    public Country(Guid id, Name name, Currency currency) : base(id)
    {
        Name = name;
        Currency = currency;
    }

    public Name Name { get; set; }

    public Currency Currency { get; set; }

    public List<City.Entities.City> Cities { get; set; } = null!;
}