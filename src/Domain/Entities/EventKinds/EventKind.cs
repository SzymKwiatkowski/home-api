using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Events;

public class EventKind : BaseAuditableEntity<EventKindId>
{
    public SeverityKind DefaultSeverity { get; private set; } = null!;

    public Name Name { get; private set; } = null!;

    public static EventKind Create(SeverityKind severityKind,
                                   Name name,
                                   EventKindId? id = null)
    {
        return new EventKind
        {
            Id = id ?? EventKindId.New(),
            DefaultSeverity = severityKind,
            Name = name,

        };
    }
}
