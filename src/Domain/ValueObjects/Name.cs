using System;

namespace HomeApi.Domain.ValueObjects;

public class Name : ValueObject
{
    public string Value { get; private set; } = null!;

    private Name()
    {
    }

    public static Name Create(string value)
    {
        return new Name
        {
            Value = value
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
