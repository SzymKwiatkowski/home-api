
namespace HomeApi.Domain.ValueObjects;

public class Description : ValueObject
{
    public string Value { get; private set; } = null!;

    private Description()
    {
    }

    public static Description Create(string value)
    {
        return new Description
        {
            Value = value
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
