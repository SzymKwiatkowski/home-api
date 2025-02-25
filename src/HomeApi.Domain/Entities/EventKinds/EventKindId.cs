namespace HomeApi.Domain.Entities.EventKinds;

public record EventKindId : StronglyTypedId<EventKindId, int>
{
    private EventKindId() { }

    public new int Value { get; private set; }

    public static new EventKindId Create(int value)
    {
        return new EventKindId { Value = value };
    }
}
