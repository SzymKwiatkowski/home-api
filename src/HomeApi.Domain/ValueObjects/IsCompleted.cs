using Throw;

namespace HomeApi.Domain.ValueObjects;

public class IsCompleted : ValueObject
{
    public bool Value { get; private set; }

    private IsCompleted() { }

    public static IsCompleted Create(bool value)
    {
        value.ThrowIfNull();

        return new IsCompleted { Value = value };
    }

    public static IsCompleted False => new IsCompleted { Value = false };

    public static IsCompleted True => new IsCompleted { Value = true };

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
