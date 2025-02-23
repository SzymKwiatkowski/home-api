using HomeApi.Domain.Entities.PaymentKinds;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities;

public class Payment : BaseAuditableEntity<PaymentId>
{
    private Payment()
    {
    }

    public Name Name { get; private set; } = null!;

    public Amount Amount { get; private set; } = null!;

    public PaymentKindId PaymentKindId { get; private set; } = null!;

    public SeverityKind Severity { get; private set; } = null!;

    public DateTimeOffset Date { get; private set; }

    public Description Description { get; private set; } = null!;

    public IsPeriodic IsPeriodic { get; private set; } = null!;

    public PeriodDefinition? PeriodDefinition { get; private set; }

    public static Payment Create(
        Name name,
        PaymentKindId paymentKindId,
        SeverityKind severity,
        Amount amount,
        DateTimeOffset date,
        Description description,
        PeriodDefinition? periodDefinition = null,
        PaymentId? id = null)
    {
        return new Payment
        {
            Id = id ?? PaymentId.New(),
            Name = name,
            PaymentKindId = paymentKindId,
            Severity = severity,
            Amount = amount,
            Date = date,
            Description = description,
            IsPeriodic = periodDefinition is null ? IsPeriodic.False : IsPeriodic.True,
            PeriodDefinition = periodDefinition
        };
    }
}
