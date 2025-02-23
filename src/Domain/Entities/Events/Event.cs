using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Events;

public class Event : BaseAuditableEntity<EventId>
{
    public IsPeriodic IsPeriodic { get; private set; } = null!;

    public PeriodDefinition? PeriodDefinition { get; private set; }

    public EventKindId EventKindId { get; private set; } = null!;

    public Name Name { get; private set; } = null!;

    public Description? Description { get; private set; } = null!;

    public SeverityKind Severity { get; private set; } = null!;
}
