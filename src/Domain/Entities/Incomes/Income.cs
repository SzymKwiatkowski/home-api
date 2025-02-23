using HomeApi.Domain.Entities.PaymentKinds;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Incomes;

public class Income : BaseAuditableEntity<IncomeId>
{
    private Income() { }

    public Name Name { get; private set; } = null!;

    public PaymentKindId PaymentKindId { get; private set; } = null!;

    public Amount Amount { get; private set; } = null!;

    public SeverityKind Severity { get; private set; } = null!;

    public DateTimeOffset Date { get; private set; }

    public Description? Description { get; private set; }

    public IsPeriodic IsPeriodic { get; private set; } = null!;

    public PeriodDefinition? PeriodDefinition { get; private set; }

    public static Income Create(
        Name name,
        PaymentKindId paymentKindId,
        SeverityKind severity,
        Amount amount,
        DateTimeOffset date,
        PeriodDefinition? periodDefinition = null,
        IncomeId? id = null
    )
    {
        return new Income
        {
            Id = id ?? IncomeId.New(),
            Name = name,
            PaymentKindId = paymentKindId,
            Severity = severity,
            Amount = amount,
            Date = date,
            Description = null,
            IsPeriodic = periodDefinition is null ? IsPeriodic.False : IsPeriodic.True,
            PeriodDefinition = periodDefinition,
        };
    }

    public void Update(
        Name? name,
        PaymentKindId? paymentKindId,
        SeverityKind? severity,
        Amount? amount,
        DateTimeOffset? date,
        Description? description
    )
    {
        Name = name ?? Name;
        PaymentKindId = paymentKindId ?? PaymentKindId;
        Severity = severity ?? Severity;
        Amount = amount ?? Amount;
        Date = date ?? Date;
        Description = description ?? Description;
    }
}
