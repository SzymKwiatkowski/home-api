namespace HomeApi.Rest.Contracts.Summaries;

public sealed record GetSummary(
    Guid Id,
    string Name,
    string? Description,
    DateTime StartTime,
    DateTime EndTime,
    decimal? OverallAmount
);