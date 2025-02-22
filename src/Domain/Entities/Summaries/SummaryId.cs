namespace HomeApi.Domain.Entities.Summaries;

public record SummaryId : StronglyTypedId<Guid>
{
    private SummaryId()
    {
    }

    public new Guid Value { get; private set; }

    public static SummaryId Create(Guid
        value)
    {
        return new SummaryId
        {
            Value = value
        };
    }

    public static SummaryId New()
    {
        return new SummaryId
        {
            Value = Guid.NewGuid()
        };
    }
}
