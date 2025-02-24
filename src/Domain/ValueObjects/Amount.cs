using System;
using Throw;

namespace HomeApi.Domain.ValueObjects;

public class Amount : ValueObject
{
    private Amount() { }

    public decimal Value { get; private set; }

    public static Amount Create(decimal value)
    {
        value.Throw().IfLessThan(0);

        return new Amount { Value = value };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
