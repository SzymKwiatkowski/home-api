namespace HomeApi.Domain.Common;

public record StronglyTypedId<T> : IStronglyTypedId
{
    public T Value { get; private set; } = default!;

    internal StronglyTypedId() { }
}
