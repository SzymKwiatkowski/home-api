using HomeApi.Application.Common.Interfaces;
using Mapster;
using HomeApi.Application.Repositories;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Entities.Entries;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using HomeApi.Rest.Contracts.Entries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entry = HomeApi.Domain.Entities.Entries.Entry;

namespace HomeApi.Web.Endpoints;

public class Entries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this);

        group.MapPost<CreateEntry, Guid>(CreateEntry, "");
        group.MapGet<List<GetEntry>>(GetEntries, "");
        group.MapPut<GetEntry>(ToggleEntry, "{id:guid}/toggle");
    }

    private async Task<IResult> CreateEntry(
        CreateEntry request,
        IEntriesRepository repository,
        IApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        try
        {
            var amount = request.Amount.HasValue
                ? Amount.Create(request.Amount.Value)
                : null;

            var description = !string.IsNullOrEmpty(request.Description)
                ? Description.Create(request.Description)
                : null;

            var entryKind = EntryKind.FromValue(request.EntryKind);
            
            var users = await context.ApplicationUsers
                .Where(x => request.UserIds.Contains(x.Id))
                .ToListAsync(cancellationToken);

            if (request.UserIds.Count != users.Count)
            {
                return Results.BadRequest(new { error = "Users count mismatch" });
            }

            var entry = Entry.Create(
                Name.Create(request.Name),
                amount,
                OccuredAtOnUtc.Create(request.OccuredAtOnUtc),
                users,
                EntryEntityKindId.Create(request.EntryEntityKindId),
                IsCompleted.Create(request.IsCompleted),
                entryKind,
                description
            );

            var result = await repository.AddAsync(entry, cancellationToken);

            if (result.IsFailure)
            {
                return Results.BadRequest(new { error = result.Error });
            }
            
            await context.SaveChangesAsync(cancellationToken);

            var response = entry.Adapt<GetEntry>();
            return Results.Created($"/api/entries/{entry.Id}", response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }

    private async Task<IResult> GetEntries(
        [FromQuery] DateTimeOffset? startDate,
        [FromQuery] DateTimeOffset? endDate,
        IEntriesRepository repository,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await repository.GetAllAsync(cancellationToken);

            if (result.IsFailure)
            {
                return Results.BadRequest(new { error = result.Error });
            }

            var entries = result.Value.AsEnumerable();

            // Filter by date range if provided
            if (startDate.HasValue)
            {
                entries = entries.Where(e => e.OccuredAtOnUtc.Value >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                entries = entries.Where(e => e.OccuredAtOnUtc.Value <= endDate.Value);
            }

            var response = entries.Adapt<List<GetEntry>>();
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }

    private async Task<IResult> ToggleEntry(
        Guid id,
        IEntriesRepository repository,
        IApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        try
        {
            var entryId = EntryId.Create(id);
            var result = await repository.GetByIdAsync(entryId, cancellationToken);

            if (result.IsFailure)
            {
                return Results.NotFound(new { error = "Entry not found" });
            }

            var entry = result.Value;
            entry.ToggleCompletion();

            var updateResult = await repository.UpdateAsync(entry, cancellationToken);

            if (updateResult.IsFailure)
            {
                return Results.BadRequest(new { error = updateResult.Error });
            }

            await context.SaveChangesAsync(cancellationToken);
            
            var response = entry.Adapt<GetEntry>();
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }
}
