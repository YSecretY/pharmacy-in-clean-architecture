using Pharmacy.Domain.Entities.Enums;

namespace Pharmacy.Domain.Entities;

public sealed class Country
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Currency Currency { get; set; } = null!;

    public List<City> Cities { get; set; } = null!;
}