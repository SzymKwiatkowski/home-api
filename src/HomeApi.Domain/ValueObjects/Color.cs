using Throw;

namespace HomeApi.Domain.ValueObjects;

public class Color : ValueObject
{
    public string Value { get; private set; } = null!;

    private Color() { }

    public static Color Create(string value)
    {
        value.ThrowIfNull();
        value.Throw().IfEmpty();

        return new Color { Value = value };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
