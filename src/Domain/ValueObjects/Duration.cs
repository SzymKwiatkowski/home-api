namespace HomeApi.Domain.ValueObjects;

public class Duration : ValueObject
{
    public DateTimeOffset Start { get; private set; }
    public DateTimeOffset End { get; private set; }

    private Duration() { }

    public static Duration Create(DateTimeOffset start, DateTimeOffset end)
    {
        return new Duration { Start = start, End = end };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}
