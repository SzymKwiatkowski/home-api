using System;
using Throw;

namespace HomeApi.Domain.Entities.Currencies.ValueObjects;

public class Code : ValueObject
{
    public string Value { get; private set; } = null!;

    public static Code Create(string value)
    {
        value.ThrowIfNull();
        value.Throw().IfEmpty();

        return new Code { Value = value };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
