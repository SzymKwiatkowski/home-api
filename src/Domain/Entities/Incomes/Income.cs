using HomeApi.Domain.Entities.PaymentKinds;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Incomes;

public class Income : BaseCalendarEntity<IncomeId>
{
    private Income() { }

    public PaymentKindId PaymentKindId { get; private set; } = null!;

    public Amount Amount { get; private set; } = null!;

    public static Income Create(
        Name name,
        PaymentKindId paymentKindId,
        SeverityKind severity,
        Amount amount,
        Duration duration,
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
            Duration = duration,
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
        Duration? duration,
        Description? description
    )
    {
        Name = name ?? Name;
        PaymentKindId = paymentKindId ?? PaymentKindId;
        Severity = severity ?? Severity;
        Amount = amount ?? Amount;
        Duration = duration ?? Duration;
        Description = description ?? Description;
    }
}
