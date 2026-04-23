using MassTransit;

namespace HomeApi.Domain.Entities.Summaries;

public record SummaryId : StronglyTypedId<SummaryId, Guid>, ICreateId<SummaryId, Guid>
{
    private SummaryId() { }

    public static SummaryId New()
    {
        return new SummaryId { Value = NewId.NextGuid() };
    }

    public static SummaryId Create(Guid value)
    {
        return new SummaryId { Value = value };
    }
}
