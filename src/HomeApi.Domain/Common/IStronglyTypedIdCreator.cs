namespace HomeApi.Domain.Common;

public interface IStronglyTypedIdCreator<out TId, in TValue>
    where TId : IStronglyTypedId
    where TValue : notnull
{
    public static abstract TId CreateStronglyTypedId(TValue value);
}
