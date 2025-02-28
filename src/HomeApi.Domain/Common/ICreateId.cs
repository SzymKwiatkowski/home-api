namespace HomeApi.Domain.Common;

public interface ICreateId<out TId, in TValue>
    where TId : IStronglyTypedId
    where TValue : notnull
{
    public static abstract TId Create(TValue value);
}
