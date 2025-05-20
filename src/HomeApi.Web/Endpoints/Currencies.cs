namespace HomeApi.Web.Endpoints;

public class Currencies : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this);
    }
}
