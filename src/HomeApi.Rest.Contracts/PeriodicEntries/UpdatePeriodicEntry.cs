namespace HomeApi.Rest.Contracts.PeriodicEntries;

public sealed record UpdatePeriodicEntry(
    string? PeriodDefinition,
    string? Name,
    string? Description,
    decimal? Amount,
    bool? IsActive,
    int EntryKind,
    short? EntryEntityKindId,
    List<string> UserIds
);
