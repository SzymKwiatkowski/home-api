namespace Infrastructure.DatabaseEF.IntegrationTests.WebApplicationSetup;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        var database = new PostgreSQLTestcontainersTestDatabase();

        await database.InitialiseAsync();

        return database;
    }
}

