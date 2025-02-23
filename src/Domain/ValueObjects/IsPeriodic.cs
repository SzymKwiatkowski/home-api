using Throw;

namespace HomeApi.Domain.ValueObjects;

public class IsPeriodic : ValueObject
{
    public bool Value { get;  private set; }

    private IsPeriodic()
    {
    }

    public static IsPeriodic Create(bool value)
    {
        value.ThrowIfNull();

        return new IsPeriodic
        {
            Value = value
        };
    }

    public static IsPeriodic False => new IsPeriodic { Value = false };

    public static IsPeriodic True => new IsPeriodic { Value = true };

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
