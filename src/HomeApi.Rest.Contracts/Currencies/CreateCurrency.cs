namespace HomeApi.Rest.Contracts.Currencies;

public sealed record CreateCurrency(
    string Name,
    string Symbol,
    string Code
);