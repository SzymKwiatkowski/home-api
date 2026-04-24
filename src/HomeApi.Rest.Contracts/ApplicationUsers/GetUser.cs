namespace HomeApi.Rest.Contracts.ApplicationUsers;

public sealed record GetUser(
    Guid Id,
    string UserName,
    string Email
);
