namespace HomeApi.Domain.Entities.EntryEntityKinds;

public record EntryEntityKindId : StronglyTypedId<EntryEntityKindId, int>, ICreateId<EntryEntityKindId, int>
{
    private EntryEntityKindId() { }
    
    public static EntryEntityKindId New()
    {
        return new EntryEntityKindId { Value = default };
    }

    public static EntryEntityKindId Create(int value)
    {
        return new EntryEntityKindId { Value = value };
    }
}
