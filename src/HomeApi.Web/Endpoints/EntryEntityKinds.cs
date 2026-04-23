using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using HomeApi.Rest.Contracts.EntryEntityKinds;
using EntryEntityKind = HomeApi.Domain.Entities.EntryEntityKinds.EntryEntityKind;
using MapsterMapper;

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
            
            var kind = EntryEntityKind.Create(
                Name.Create(request.Name),
                entryKind
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
