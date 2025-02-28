using System;
using Throw;

namespace HomeApi.Domain.Entities.Currencies.ValueObjects;

public class Symbol : ValueObject
{
    public string Value { get; private set; } = null!;

    public static Symbol Create(string value)
    {
        value.ThrowIfNull();
        value.Throw().IfEmpty();

        return new Symbol { Value = value };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
