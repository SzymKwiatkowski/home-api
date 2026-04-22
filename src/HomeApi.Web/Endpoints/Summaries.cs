using Mapster;
using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.Entities.Summaries;
using HomeApi.Domain.ValueObjects;
using HomeApi.Rest.Contracts.Summaries;
using Microsoft.AspNetCore.Mvc;
using Summary = HomeApi.Domain.Entities.Summaries.Summary;
using MapsterMapper;

namespace HomeApi.Web.Endpoints;

public class Summaries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this);

        group.MapPost(CreateSummary, "");
        group.MapGet(GetSummaries, "");
    }

    private async Task<IResult> CreateSummary(
        CreateSummary request,
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var startDate = new DateTimeOffset(request.StartTime);
            var endDate = new DateTimeOffset(request.EndTime);
            
            var duration = Duration.Create(startDate, endDate);
            var name = Name.Create($"Summary {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");

            var summary = Summary.Create(
                name,
                duration,
                null
            );

            context.Summaries.Add(summary);
            await context.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<GetSummary>(summary);
            return Results.Created($"/api/summaries/{summary.Id.Value}", response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }

    private Task<IResult> GetSummaries(
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate,
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var summaries = context.Summaries.AsEnumerable().ToList();

            // Filter by date range if provided
            if (startDate.HasValue || endDate.HasValue)
            {
                summaries = summaries.Where(s =>
                {
                    if (startDate.HasValue && s.Duration.Start < new DateTimeOffset(startDate.Value))
                        return false;
                    if (endDate.HasValue && s.Duration.End.HasValue && s.Duration.End.Value > new DateTimeOffset(endDate.Value))
                        return false;
                    return true;
                }).ToList();
            }

            var response = mapper.Map<List<GetSummary>>(summaries);
            return Task.FromResult(Results.Ok(response));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Results.BadRequest(new { error = ex.Message }));
        }
    }
}
