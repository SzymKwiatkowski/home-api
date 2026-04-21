using Throw;

public class OccuredAtOnUtc : ValueObject
{
    public DateTimeOffset Value { get; private set; } = DateTimeOffset.MinValue;

    private OccuredAtOnUtc() { }

    public static OccuredAtOnUtc Create(DateTimeOffset value)
    {
        value.ThrowIfNull();

        return new OccuredAtOnUtc { Value = value };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}