using HomeApi.Domain.Entities.IncomeKinds;
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
        OccuredAtOnUtc occuredAtOnUtc,
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
            OccuredAtOnUtc = occuredAtOnUtc,
            Description = null
        };
    }

    public void Update(
        Name? name,
        IncomeKindId? incomeKindId,
        SeverityKind? severity,
        Amount? amount,
        OccuredAtOnUtc? occuredAtOnUtc,
        Description? description
    )
    {
        Name = name ?? Name;
        IncomeKindId = incomeKindId ?? IncomeKindId;
        Severity = severity ?? Severity;
        Amount = amount ?? Amount;
        Description = description ?? Description;
        OccuredAtOnUtc = occuredAtOnUtc ?? OccuredAtOnUtc;
    }
}
