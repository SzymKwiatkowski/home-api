namespace HomeApi.Rest.Contracts.Entries;

public sealed record CreateEntry(
    int EventKind,
    string Name,
    decimal? Amount,
    List<string> UserIds,
    DateTimeOffset OccuredAtOnUtc,
    string? Description,
    int? EntryEntityKindId
);
