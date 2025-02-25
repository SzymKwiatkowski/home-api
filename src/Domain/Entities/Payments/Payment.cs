using HomeApi.Domain.Entities.PaymentKinds;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities;

public class Payment : BaseCalendarEntity<PaymentId>
{
    private Payment() { }

    public Amount Amount { get; private set; } = null!;

    public PaymentKindId PaymentKindId { get; private set; } = null!;

    public static Payment Create(
        Name name,
        PaymentKindId paymentKindId,
        SeverityKind severity,
        Amount amount,
        Duration duration,
        PeriodDefinition? periodDefinition = null,
        PaymentId? id = null
    )
    {
        return new Payment
        {
            Id = id ?? PaymentId.New(),
            Name = name,
            PaymentKindId = paymentKindId,
            Severity = severity,
            Amount = amount,
            Duration = duration,
            Description = null,
            IsPeriodic = periodDefinition is null ? IsPeriodic.False : IsPeriodic.True,
            PeriodDefinition = periodDefinition,
        };
    }
}
