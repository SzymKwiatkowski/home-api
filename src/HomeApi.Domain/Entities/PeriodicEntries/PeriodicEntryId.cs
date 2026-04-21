using MassTransit;

namespace HomeApi.Domain.Entities.PeriodicEntries;

public record PeriodicEntryId : StronglyTypedId<PeriodicEntryId, Guid>
{
    private PeriodicEntryId() { }

    public static new PeriodicEntryId Create(Guid value)
    {
        return new PeriodicEntryId { Value = value };
    }

    public static PeriodicEntryId New()
    {
        return new PeriodicEntryId { Value = NewId.NextGuid() };
    }
};
