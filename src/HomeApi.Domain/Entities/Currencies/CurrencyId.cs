namespace HomeApi.Domain.Entities.Currencies;

public record CurrencyId : StronglyTypedId<CurrencyId, int>, ICreateId<CurrencyId, int>
{
    private CurrencyId() { }

    public static CurrencyId New()
    {
        return new CurrencyId { Value = 0 };
    }

    public static CurrencyId Create(int value)
    {
        return new CurrencyId {Value =  value};
    }
}
