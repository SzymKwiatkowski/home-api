using Mapster;
using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.ValueObjects;
using HomeApi.Rest.Contracts.PeriodicEntries;
using PeriodicEntry = HomeApi.Domain.Entities.PeriodicEntries.PeriodicEntry;
using MapsterMapper;

namespace HomeApi.Web.Endpoints;

public class PeriodicEntries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this);

        group.MapPost(CreatePeriodicEntry, "");
        group.MapGet(GetPeriodicEntries, "");
    }

    private async Task<IResult> CreatePeriodicEntry(
        CreatePeriodicEntry request,
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var startDate = request.OccuredAtOnUtc ?? DateTimeOffset.UtcNow;
            
            var duration = Duration.Create(startDate, null);
            var periodDefinition = PeriodDefinition.Create(request.PeriodDefinition);
            var amount = request.Amount.HasValue ? Amount.Create(request.Amount.Value) : null;
            var description = !string.IsNullOrEmpty(request.Name) ? Description.Create(request.Name) : null;

            var entry = PeriodicEntry.Create(
                duration,
                periodDefinition,
                Name.Create(request.Name),
                description,
                amount,
                request.UserIds
            );

            context.PeriodicEntries.Add(entry);
            await context.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<GetPeriodicEntry>(entry);
            return Results.Created($"/api/periodicentries/{entry.Id!.Value}", response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }

    private Task<IResult> GetPeriodicEntries(
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var entries = context.PeriodicEntries.AsEnumerable().ToList();
            var response = mapper.Map<List<GetPeriodicEntry>>(entries);
            return Task.FromResult(Results.Ok(response));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Results.BadRequest(new { error = ex.Message }));
        }
    }
}
