using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.Common.ValueObjects.CountryIsoCode;
using Pharmacy.Domain.Common.ValueObjects.Name;
using Pharmacy.Domain.PharmacyAggregate.Entities;

namespace Pharmacy.Domain.PharmacyAggregate;

public sealed class Pharmacy : AggregateRoot<Guid>
{
    public Pharmacy(Guid id, Name name, CountryIsoCode countryIsoCode) : base(id)
    {
        Name = name;
        CountryIsoCode = countryIsoCode;
    }

    public Name Name { get; set; }

    public CountryIsoCode CountryIsoCode { get; set; }

    public List<User.User> Users { get; set; } = null!;

    public List<Order> Orders { get; set; } = null!;

    public List<Product> Products { get; set; } = null!;
}