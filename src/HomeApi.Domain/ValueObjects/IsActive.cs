using Throw;

namespace HomeApi.Domain.ValueObjects;

public class IsActive : ValueObject
{
    public bool Value { get; private set; }

    private IsActive() { }

    public static IsActive Create(bool value)
    {
        value.ThrowIfNull();

        return new IsActive { Value = value };
    }

    public static IsActive False => new IsActive { Value = false };

    public static IsActive True => new IsActive { Value = true };

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
