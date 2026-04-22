namespace HomeApi.Rest.Contracts.EntryEntityKinds;

public sealed record GetEntryEntityKind(
    Guid Id,
    string Name,
    int EntryKind
);