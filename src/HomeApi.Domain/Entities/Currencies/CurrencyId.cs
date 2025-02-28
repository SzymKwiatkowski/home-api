namespace HomeApi.Domain.Entities.Currencies;

public record CurrencyId : StronglyTypedId<CurrencyId, int>
{
    private CurrencyId() { }

    public new int Value { get; private set; }

    public static new CurrencyId Create(int value)
    {
        return new CurrencyId { Value = value };
    }
}
