using Pharmacy.Domain.Common.Models;
using Pharmacy.Domain.ValueObjects;

namespace Pharmacy.Domain.Entities.Pharmacy.Entities;

public sealed class Pharmacy : Entity<Guid>
{
    public Pharmacy(Guid id, Name name, string countryIsoCode) : base(id)
    {
        Name = name;
        CountryIsoCode = countryIsoCode;
    }

    public Name Name { get; set; }

    public string CountryIsoCode { get; set; }

    public List<Product.Entities.Product> Products { get; set; } = null!;
}