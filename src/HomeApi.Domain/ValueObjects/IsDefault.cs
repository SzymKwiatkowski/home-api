using Throw;

namespace HomeApi.Domain.ValueObjects;

public class IsDefault : ValueObject
{
    public bool Value { get; private set; }

    private IsDefault() { }

    public static IsDefault Create(bool value)
    {
        value.ThrowIfNull();

        return new IsDefault { Value = value };
    }

    public static IsDefault False => new IsDefault { Value = false };

    public static IsDefault True => new IsDefault { Value = true };

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
