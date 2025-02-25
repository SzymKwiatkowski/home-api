using Throw;

namespace HomeApi.Domain.ValueObjects;

public class Duration : ValueObject
{
    public DateTimeOffset Start { get; private set; }

    public DateTimeOffset? End { get; private set; }

    private Duration() { }

    public static Duration Create(DateTimeOffset start, DateTimeOffset? end)
    {
        if (end is not null)
        {
            start.Throw().IfFalse(s => s < end);
        }

        return new Duration { Start = start, End = end };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End ?? DateTimeOffset.MaxValue;
    }
}
