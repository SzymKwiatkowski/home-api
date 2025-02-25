using Microsoft.AspNetCore.Http.HttpResults;

namespace HomeApi.Web.Endpoints;

public class WeatherForecasts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization();
    }
}