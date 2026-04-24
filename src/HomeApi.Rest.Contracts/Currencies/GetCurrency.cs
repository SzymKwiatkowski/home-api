namespace HomeApi.Rest.Contracts.Currencies;

public sealed record GetCurrency(
    int Id,
    string Name,
    string Symbol,
    string Code,
    bool IsDefault
);
