namespace HomeApi.Domain.Common;

public record StronglyTypedId<TId, TValue> : IEntityId<TValue>, ICreateId<TId, TValue>
    where TId : IEntityId<TValue>, ICreateId<TId, TValue>
    where TValue : notnull
{
    protected StronglyTypedId() { }

    public TValue Value { get; protected set; } = default!;

    public static TId Create(TValue value)
    {
        return TId.Create(value);
    }
}
