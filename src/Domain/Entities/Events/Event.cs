using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Events;

public class Event : BaseCalendarEntity<EventId>
{
    public EventKindId EventKindId { get; private set; } = null!;

    private Event() { }

    public static Event Create(
        EventKindId eventKindId,
        Name name,
        SeverityKind severity,
        Duration duration,
        Description? description,
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
            Duration = duration,
            Description = description,
            IsPeriodic = periodDefinition is null ? IsPeriodic.False : IsPeriodic.True,
            PeriodDefinition = periodDefinition,
        };
    }
}
