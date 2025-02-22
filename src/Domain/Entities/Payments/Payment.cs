using HomeApi.Domain.Entities.PaymentKinds;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities;

public class Payment : BaseAuditableEntity<PaymentId>
{
    private Payment()
    {
    }

    public Name Name { get; private set; } = default!;

    public PaymentKind PaymentKind { get; private set; } = default!;

    public Amount Amount { get; private set; } = default!;

    public DateTimeOffset Date { get; private set; }

    public Description Description { get; private set; } = default!;

    public static Payment Create(
        Name name,
        PaymentKind paymentKind,
        Amount amount,
        DateTimeOffset date,
        Description description,
        PaymentId? id = null)
    {
        return new Payment
        {
            Id = id ?? PaymentId.New(),
            Name = name,
            PaymentKind = paymentKind,
            Amount = amount,
            Date = date,
            Description = description
        };
    }
}
