using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.Entities.ApplicationUsers;
using HomeApi.Rest.Contracts.ApplicationUsers;
using HomeApi.Rest.Contracts.Currencies;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeApi.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this);
        
        group.MapIdentityApi<ApplicationUser>();

        group.MapGet<List<GetUser>>(GetUsers, "");
    }

    private async Task<IResult> GetUsers(
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var applicationUsers = await context.ApplicationUsers.ToListAsync(cancellationToken);
            var response = mapper.Map<List<GetUser>>(applicationUsers);
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }
}
