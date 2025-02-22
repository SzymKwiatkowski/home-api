namespace HomeApi.Domain.Entities.Currencies;

public record CurrencyId : StronglyTypedId<int>
{
    private CurrencyId()
    {
    }
    
    public new int Value { get; private set; }

    public static CurrencyId Create(int value)
    {
        return new CurrencyId
        {
            Value = value
        };
    }
}
