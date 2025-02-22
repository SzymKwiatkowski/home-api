using System;

namespace HomeApi.Domain.ValueObjects;

public class Amount : ValueObject
{
    private Amount()
    {
    }

    public decimal Value { get; private set; }

    public static Amount Create(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }

        return new Amount { Value = value };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
