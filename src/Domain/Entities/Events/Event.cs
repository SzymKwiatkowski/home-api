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

    public DateTimeOffset Date { get; private set; }

    private Event() { }

    public static Event Create(
        EventKindId eventKindId,
        Name name,
        SeverityKind severity,
        DateTimeOffset date,
        Description description,
        PeriodDefinition? periodDefinition = null,
        EventId? id = null
    )
    {
        return new Event
        {
            Id = id ?? EventId.New(),
            EventKindId = eventKindId,
            Name = name,
            Severity = severity,
            Date = date,
            Description = description,
            IsPeriodic = periodDefinition is null ? IsPeriodic.False : IsPeriodic.True,
            PeriodDefinition = periodDefinition,
        };
    }
}
