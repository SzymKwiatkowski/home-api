using HomeApi.Domain.Entities.Currencies.ValueObjects;
using HomeApi.Domain.ValueObjects;
using Throw;

namespace HomeApi.Domain.Entities.Currencies;

public class Currency : BaseAuditableEntity<CurrencyId>
{
    // eg. USD, PLN
    public Code Code { get; private set; } = null!;

    // eg. $, zł
    public Symbol Symbol { get; private set; } = null!;

    // eg. United States Dollar, Polski złoty
    public Name Name { get; private set; } = null!;

    public static Currency Create(Code code, Symbol symbol, Name name, CurrencyId? id = null)
    {
        code.ThrowIfNull();
        symbol.ThrowIfNull();
        name.ThrowIfNull();

        return new Currency
        {
            Id = id,
            Code = code,
            Symbol = symbol,
            Name = name,
        };
    }
}
