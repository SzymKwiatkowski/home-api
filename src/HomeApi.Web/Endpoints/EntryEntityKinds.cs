using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using HomeApi.Rest.Contracts.EntryEntityKinds;
using EntryEntityKind = HomeApi.Domain.Entities.EntryEntityKinds.EntryEntityKind;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeApi.Web.Endpoints;

public class EntryEntityKinds : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this);

        group.MapPost<CreateEntryEnityKind, int>(CreateEntryEntityKind, "");
        group.MapGet<List<GetEntryEntityKind>>(GetEntryEntityKinds, "");
    }

    private async Task<IResult> CreateEntryEntityKind(
        CreateEntryEnityKind request,
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var entryKind = (EntryKind)request.EntryKind;
            

            var entryEntityKindsMaxId = context.EntryEntityKinds.AsNoTracking()
                .Where(x => x.EntryKind == entryKind)
                .Max(x => x.Id);
            
            var kind = EntryEntityKind.Create(
                Name.Create(request.Name),
                entryKind,
                Emoji.Create(request.Icon),
                Color.Create(request.Color),
                EntryEntityKindId.Create(entryEntityKindsMaxId?.Value ?? 
                                         (short)((400 * (entryKind.Value-1)) + 1))
            );
            
            context.EntryEntityKinds.Add(kind);
            await context.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<GetEntryEntityKind>(kind);
            return Results.Created($"/api/entry-entity-kinds/{kind.Id!.Value}", response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }

    private Task<IResult> GetEntryEntityKinds(
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var kinds = context.EntryEntityKinds.AsEnumerable().ToList();
            var response = mapper.Map<List<GetEntryEntityKind>>(kinds);
            return Task.FromResult(Results.Ok(response));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Results.BadRequest(new { error = ex.Message }));
        }
    }
}
