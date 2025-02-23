namespace HomeApi.Domain.Entities.Events;

public record EventId : StronglyTypedId<Guid>
{
    private EventId() { }

    public new Guid Value { get; private set; }

    public static EventId Create(Guid value)
    {
        return new EventId { Value = value };
    }

    public static EventId New()
    {
        return new EventId { Value = Guid.NewGuid() };
    }
};
