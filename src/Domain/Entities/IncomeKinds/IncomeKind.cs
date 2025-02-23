using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using Throw;

namespace HomeApi.Domain.Entities.IncomeKinds;

public class IncomeKind : BaseAuditableEntity<IncomeKindId>
{
    private IncomeKind()
    {
    }

    public SeverityKind DefaultSeverity { get; private set; } = null!;

    public Name Name { get; private set; } = null!;

    public static IncomeKind Create(SeverityKind severityKind,
                                    Name name,
                                    IncomeKindId? id = null)
    {
        severityKind.ThrowIfNull();
        name.ThrowIfNull();

        return new IncomeKind
        {
            Id = id,
            DefaultSeverity = severityKind,
            Name = name,
        };
    }
}
