using System;
using Throw;

namespace HomeApi.Domain.ValueObjects;

public class Name : ValueObject
{
    public string Value { get; private set; } = null!;

    private Name() { }

    public static Name Create(string value)
    {
        value.ThrowIfNull();
        value.Throw().IfEmpty();

        return new Name { Value = value };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
