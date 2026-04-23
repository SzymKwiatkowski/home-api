namespace HomeApi.Domain.Common;

public abstract record StronglyTypedId<TId, TValue> : IEntityId<TValue>, IStronglyTypedIdCreator<TId, TValue>
    where TId : StronglyTypedId<TId, TValue>, ICreateId<TId, TValue>
    where TValue : notnull
{
    protected StronglyTypedId() { }

    public TValue Value { get; protected set; } = default!;

    public static TId CreateStronglyTypedId(TValue value)
    {
        return TId.Create(value);
    }
}
