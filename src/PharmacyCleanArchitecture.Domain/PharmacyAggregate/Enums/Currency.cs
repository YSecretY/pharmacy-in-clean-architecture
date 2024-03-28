using Ardalis.SmartEnum;

namespace PharmacyCleanArchitecture.Domain.PharmacyAggregate.Enums;

public sealed class Currency : SmartEnum<Currency>
{
    public static readonly Currency Uah = new Currency(nameof(Uah), 1);
    public static readonly Currency Eur = new Currency(nameof(Eur), 2);
    public static readonly Currency Usd = new Currency(nameof(Usd), 3);
    
    private Currency(string name, int value) : base(name, value)
    {
    }
}