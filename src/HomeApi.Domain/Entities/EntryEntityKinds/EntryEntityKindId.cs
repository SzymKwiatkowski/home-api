namespace HomeApi.Domain.Entities.EntryEntityKinds;

public record EntryEntityKindId : StronglyTypedId<EntryEntityKindId, int>
{
    private EntryEntityKindId() { }

    public new int Value { get; private set; }

    public static new EntryEntityKindId Create(int value)
    {
        return new EntryEntityKindId { Value = value };
    }

    public static EntryEntityKindId New()
    {
        return new EntryEntityKindId { Value = default };
    }
}
