namespace HomeApi.Domain.Entities.EntryEntityKinds;

public record EntryEntityKindId : StronglyTypedId<EntryEntityKindId, short>, ICreateId<EntryEntityKindId, short>
{
    private EntryEntityKindId() { }
    
    public static EntryEntityKindId New()
    {
        return new EntryEntityKindId { Value = default };
    }

    public static EntryEntityKindId Create(short value)
    {
        return new EntryEntityKindId { Value = value };
    }
}
