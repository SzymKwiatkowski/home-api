namespace HomeApi.Domain.Entities.Payments;

public record PaymentId : StronglyTypedId<PaymentId, Guid>
{
    private PaymentId() { }

    public static new PaymentId Create(Guid value)
    {
        return new PaymentId { Value = value };
    }

    public static PaymentId New()
    {
        return new PaymentId { Value = Guid.NewGuid() };
    }
}
