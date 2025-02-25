namespace HomeApi.Domain.Common;

public interface IEntityId<T> : IStronglyTypedId
    where T : notnull
{
    public T Value { get; }
}
