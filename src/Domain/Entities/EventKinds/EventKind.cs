using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using Throw;

namespace HomeApi.Domain.Entities.Events;

public class EventKind : BaseAuditableEntity<EventKindId>
{
    private EventKind()
    {
    }

    public SeverityKind DefaultSeverity { get; private set; } = null!;

    public Name Name { get; private set; } = null!;

    public static EventKind Create(SeverityKind severityKind,
                                   Name name,
                                   EventKindId? id = null)
    {
        severityKind.ThrowIfNull();
        name.ThrowIfNull();

        return new EventKind
        {
            Id = id,
            DefaultSeverity = severityKind,
            Name = name,
        };
    }
}
