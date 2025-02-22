namespace HomeApi.Domain.Entities;

public record PaymentId : StronglyTypedId<Guid>
{
    private PaymentId()
    {
    }

    public new Guid Value { get; private set; }

    public static PaymentId New()
    {
        return new PaymentId
        {
            Value = Guid.NewGuid()
        };
    }
}