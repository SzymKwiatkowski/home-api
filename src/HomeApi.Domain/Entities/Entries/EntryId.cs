using MassTransit;

namespace HomeApi.Domain.Entities.Entries;

public record EntryId : StronglyTypedId<EntryId, Guid>, ICreateId<EntryId, Guid>
{
    private EntryId() { }

    public static EntryId New()
    {
        return new EntryId { Value = NewId.NextGuid() };
    }

    public static EntryId Create(Guid value)
    {
        return new EntryId { Value = value };
    }
}
