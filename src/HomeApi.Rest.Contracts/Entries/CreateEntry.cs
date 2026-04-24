namespace HomeApi.Rest.Contracts.Entries;

public sealed record CreateEntry(
    int EntryKind,
    string Name,
    decimal? Amount,
    List<string> UserIds,
    DateTimeOffset OccuredAtOnUtc,
    bool IsCompleted,
    string? Description,
    short EntryEntityKindId
);
