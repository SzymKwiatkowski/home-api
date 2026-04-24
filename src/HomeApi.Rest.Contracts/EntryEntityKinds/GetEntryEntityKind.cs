namespace HomeApi.Rest.Contracts.EntryEntityKinds;

public sealed record GetEntryEntityKind(
    int Id,
    string Name,
    int EntryKind,
    string Icon,
    string Color
);
