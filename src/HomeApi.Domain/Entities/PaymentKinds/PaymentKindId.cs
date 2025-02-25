namespace HomeApi.Domain.Entities.PaymentKinds;

public record PaymentKindId : StronglyTypedId<PaymentKindId, int>
{
    private PaymentKindId() { }

    public new int Value { get; private set; }

    public static new PaymentKindId Create(int value)
    {
        return new PaymentKindId { Value = value };
    }
}
