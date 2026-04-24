using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Entities.PeriodicEntries;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using HomeApi.Rest.Contracts.PeriodicEntries;
using Mapster;
using PeriodicEntry = HomeApi.Domain.Entities.PeriodicEntries.PeriodicEntry;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeApi.Web.Endpoints;

public class PeriodicEntries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this);

        group.MapPost<CreatePeriodicEntry, Guid>(CreatePeriodicEntry, "");
        group.MapPut<UpdatePeriodicEntry>(UpdatePeriodicEntry, "{id:guid}");
        group.MapPut<UpdatePeriodicEntry>(TogglePeriodicEntry, "{id:guid}");
        group.MapGet<List<GetPeriodicEntry>>(GetPeriodicEntries, "");
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
            
            var users = await context.ApplicationUsers
                .Where(x => request.UserIds.Contains(x.Id))
                .ToListAsync(cancellationToken);

            if (request.UserIds.Count != users.Count)
            {
                return Results.BadRequest(new { error = "Users count mismatch" });
            }

            var entry = PeriodicEntry.Create(
                duration,
                periodDefinition,
                Name.Create(request.Name),
                description,
                amount,
                users,
                IsActive.Create(request.IsActive),
                EntryKind.FromValue(request.EntryKind),
                EntryEntityKindId.Create(request.EntryEntityKindId)
            );

            context.PeriodicEntries.Add(entry);
            await context.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<GetPeriodicEntry>(entry);
            return Results.Created($"/api/periodic-entries/{entry.Id!.Value}", response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }
    
    private async Task<IResult> UpdatePeriodicEntry(
        Guid Id,
        UpdatePeriodicEntry request,
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var periodicEntry = await context.PeriodicEntries
                .FindAsync(PeriodicEntryId.Create(Id), cancellationToken, cancellationToken);

            if (periodicEntry == null)
            {
                return Results.NotFound();
            }
            
            var users = await context.ApplicationUsers
                .Where(x => request.UserIds.Contains(x.Id))
                .ToListAsync(cancellationToken);

            if (request.UserIds.Count != users.Count)
            {
                return Results.BadRequest(new { error = "Users count mismatch" });
            }

            periodicEntry.Update(
                null,
                request.PeriodDefinition is null ? null : PeriodDefinition.Create(request.PeriodDefinition),
                request.Name is null ? null : Name.Create(request.Name),
                request.Description is null ? null : Description.Create(request.Description),
                request.Amount is null ? null : Amount.Create(request.Amount.Value),
                users,
                request.IsActive is null ? null : IsActive.Create(request.IsActive.Value),
                EntryKind.FromValue(request.EntryKind),
                request.EntryEntityKindId is null ? null : EntryEntityKindId.Create(request.EntryEntityKindId.Value)
            );

            context.PeriodicEntries.Update(periodicEntry);
            await context.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<GetPeriodicEntry>(periodicEntry);
            return Results.Ok(response);
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
            var entries = context.PeriodicEntries.AsNoTracking().AsEnumerable().ToList();
            var response = mapper.Map<List<GetPeriodicEntry>>(entries);
            return Task.FromResult(Results.Ok(response));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Results.BadRequest(new { error = ex.Message }));
        }
    }
    
    private async Task<IResult> TogglePeriodicEntry(
        Guid id,
        IApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        try
        {
            var periodicEntryId = PeriodicEntryId.Create(id);
            var result = await context.PeriodicEntries.FindAsync(periodicEntryId, cancellationToken);

            if (result is null)
            {
                return Results.NotFound(new { error = "Entry not found" });
            }

            result.ToggleIsActive();

            var updateResult = context.PeriodicEntries.Update(result);

            var response = updateResult.Adapt<GetPeriodicEntry>();
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }
}
