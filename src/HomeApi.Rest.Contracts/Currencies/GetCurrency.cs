namespace HomeApi.Rest.Contracts.Currencies;

public sealed record GetCurrency(
    Guid Id,
    string Name,
    string Symbol,
    string Code
);