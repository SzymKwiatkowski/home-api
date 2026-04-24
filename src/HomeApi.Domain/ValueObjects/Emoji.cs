using Throw;

namespace HomeApi.Domain.ValueObjects;

public class Emoji : ValueObject
{
    public string Value { get; private set; } = null!;

    private Emoji() { }

    public static Emoji Create(string value)
    {
        value.ThrowIfNull();
        value.Throw().IfEmpty();

        return new Emoji { Value = value };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
