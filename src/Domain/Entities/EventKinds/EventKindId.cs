namespace HomeApi.Domain.Entities.Events;

public record EventKindId : StronglyTypedId<int>
{
    private EventKindId()
    {
    }
    
    public new int Value { get; private set; }

    public static EventKindId Create(int value)
    {
        return new EventKindId
        {
            Value = value
        };
    }

    public static EventKindId New()
    {
        return new EventKindId
        {
            Value = 0
        };
    }
}
