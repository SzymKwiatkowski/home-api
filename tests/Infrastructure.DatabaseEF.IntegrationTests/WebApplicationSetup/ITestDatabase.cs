using System.Data.Common;

namespace Infrastructure.DatabaseEF.IntegrationTests.WebApplicationSetup;

public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    string GetConnectionString();

    Task ResetAsync();

    Task DisposeAsync();
}
