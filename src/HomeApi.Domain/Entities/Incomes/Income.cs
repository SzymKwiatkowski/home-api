using HomeApi.Domain.Entities.IncomeKinds;
using HomeApi.Domain.Entities.PaymentKinds;
using HomeApi.Domain.Entities.Summaries;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Incomes;

public class Income : BaseCalendarEntity<IncomeId>
{
    private Income() { }

    public IncomeKindId IncomeKindId { get; private set; } = null!;

    public Amount Amount { get; private set; } = null!;

    public static Income Create(
        Name name,
        IncomeKindId incomeKindId,
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
            IncomeKindId = incomeKindId,
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
        IncomeKindId? incomeKindId,
        SeverityKind? severity,
        Amount? amount,
        Duration? duration,
        Description? description
    )
    {
        Name = name ?? Name;
        IncomeKindId = incomeKindId ?? IncomeKindId;
        Severity = severity ?? Severity;
        Amount = amount ?? Amount;
        Duration = duration ?? Duration;
        Description = description ?? Description;
    }
}
