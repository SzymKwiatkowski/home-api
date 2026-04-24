namespace HomeApi.Rest.Contracts.PeriodicEntries;

public sealed record GetPeriodicEntry(
    Guid Id,
    DateTime? OccuredAtOnUtc,
    string PeriodDefinition,
    string Name,
    decimal? Amount,
    bool IsActive,
    short EntryEntityKindId,
    int EntryKind,
    List<string> UserIds
);
