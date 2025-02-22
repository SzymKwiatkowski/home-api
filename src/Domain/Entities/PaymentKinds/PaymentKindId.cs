namespace HomeApi.Domain.Entities.PaymentKinds;

public record PaymentKindId : StronglyTypedId<int>
{
    private PaymentKindId()
    {
    }

    public new int Value { get; private set; }

    public static PaymentKindId Create(int value)
    {
        return new PaymentKindId { Value = value };
    }
}
