using HomeApi.Domain.Extensions;
using Throw;

namespace HomeApi.Domain.ValueObjects;

public class PeriodDefinition : ValueObject
{
    private PeriodDefinition() { }

    public string Value { get; private set; } = null!;

    public static PeriodDefinition Create(string value)
    {
        value.Throw().IfFalse(v => v.IsValidSchedule(), "Invalid schedule format: {value}");

        return new PeriodDefinition { Value = value };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
