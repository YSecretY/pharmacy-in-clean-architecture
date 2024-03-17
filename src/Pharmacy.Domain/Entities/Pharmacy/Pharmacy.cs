using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Entities.Pharmacy.Entities;
using Pharmacy.Domain.Entities.Pharmacy.ValueObjects;

namespace Pharmacy.Domain.Entities.Pharmacy;

public sealed class Pharmacy : AggregateRoot<Guid>
{
    public Pharmacy(Guid id, Name name, CountryIsoCode countryIsoCode) : base(id)
    {
        Name = name;
        CountryIsoCode = countryIsoCode;
    }

    public Name Name { get; set; }

    public CountryIsoCode CountryIsoCode { get; set; }

    public List<Order> Orders { get; set; } = null!;

    public List<Product> Products { get; set; } = null!;
}