namespace HomeApi.Rest.Contracts.Summaries;

public sealed record CreateSummary(
    DateTime StartTime,
    DateTime EndTime
);