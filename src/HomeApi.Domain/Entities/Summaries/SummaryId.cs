namespace HomeApi.Domain.Entities.Summaries;

public record SummaryId : StronglyTypedId<SummaryId, Guid>
{
    private SummaryId() { }

    public new Guid Value { get; private set; }

    public static new SummaryId Create(Guid value)
    {
        return new SummaryId { Value = value };
    }

    public static SummaryId New()
    {
        return new SummaryId { Value = Guid.NewGuid() };
    }
}
