using HomeApi.Domain.Entities.ApplicationUser;
using HomeApi.Infrastructure.Identity;

namespace HomeApi.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
