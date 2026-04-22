using MassTransit;

namespace HomeApi.Domain.Entities.Entries;

public record EntryId : StronglyTypedId<EntryId, Guid>
{
    private EntryId() { }

    public new Guid Value { get; private set; }

    public static new EntryId Create(Guid value)
    {
        return new EntryId { Value = value };
    }

    public static EntryId New()
    {
        return new EntryId { Value = NewId.NextGuid() };
    }
}
