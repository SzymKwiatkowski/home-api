param(
    $name
)

dotnet-ef migrations add --project .\src\HomeApi.Infrastructure\HomeApi.Infrastructure.csproj --startup-project .\src\HomeApi.Web\HomeApi.Web.csproj --output-dir Data\Migrations\ --context ApplicationDbContext $name