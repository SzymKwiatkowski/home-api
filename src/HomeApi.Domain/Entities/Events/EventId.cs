namespace HomeApi.Domain.Entities.Events;

public record EventId : StronglyTypedId<EventId, Guid>
{
    private EventId() { }

    public static new EventId Create(Guid value)
    {
        return new EventId { Value = value };
    }

    public static EventId New()
    {
        return new EventId { Value = Guid.NewGuid() };
    }
};
