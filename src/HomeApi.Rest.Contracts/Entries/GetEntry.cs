namespace HomeApi.Rest.Contracts.Entries;

public sealed record GetEntry(
    int EventKind,
    string Name,
    DateTimeOffset OccuredAtOnUtc,
    string? Description,
    decimal Amount,
    Guid Id,
    List<string> UserIds,
    int? EntryEntityKindId
);
