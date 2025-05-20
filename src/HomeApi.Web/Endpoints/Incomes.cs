namespace HomeApi.Web.Endpoints;

public class Incomes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this);
    }
}
