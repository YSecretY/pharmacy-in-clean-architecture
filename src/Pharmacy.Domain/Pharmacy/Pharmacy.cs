using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Pharmacy.Entities;
using Pharmacy.Domain.Pharmacy.ValueObjects;

namespace Pharmacy.Domain.Pharmacy;

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