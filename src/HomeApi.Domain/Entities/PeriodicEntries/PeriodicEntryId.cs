using MassTransit;

namespace HomeApi.Domain.Entities.PeriodicEntries;

public record PeriodicEntryId : StronglyTypedId<PeriodicEntryId, Guid>, ICreateId<PeriodicEntryId, Guid>
{
    private PeriodicEntryId() { }

    public static PeriodicEntryId New()
    {
        return new PeriodicEntryId { Value = NewId.NextGuid() };
    }

    public static PeriodicEntryId Create(Guid value)
    {
        return new PeriodicEntryId { Value = value };
    }
};
