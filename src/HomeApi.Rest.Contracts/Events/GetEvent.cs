namespace HomeApi.Rest.Contracts.Events;

public sealed record GetEvent(
    int EventKindId,
    string Name,
    int SeverityKind,
    DateTimeOffset StartTime,
    DateTimeOffset? EndTime,
    string? Description,
    string? PeriodDefinition,
    Guid Id
);
