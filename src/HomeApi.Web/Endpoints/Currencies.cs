using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.Entities.Currencies;
using HomeApi.Domain.Entities.Currencies.ValueObjects;
using Currency = HomeApi.Domain.Entities.Currencies.Currency;
using MapsterMapper;
using HomeApi.Domain.ValueObjects;
using HomeApi.Rest.Contracts.Currencies;
using Microsoft.EntityFrameworkCore;

namespace HomeApi.Web.Endpoints;

public class Currencies : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this);

        group.MapPost<CreateCurrency, int>(CreateCurrency, "");
        group.MapGet<List<GetCurrency>>(GetCurrencies, "");
        group.MapPut<List<Currencies>>(SetAsDefault, "{id:int}");
        group.MapDelete<DeleteCurrency, int>(DeleteCurrency, "{id:int}");
    }

    private async Task<IResult> CreateCurrency(
        CreateCurrency request,
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var currency = Currency.Create(
                Code.Create(request.Code),
                Symbol.Create(request.Symbol),
                Name.Create(request.Name)
            );

            context.Currencies.Add(currency);
            await context.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<GetCurrency>(currency);
            return Results.Created($"/api/currencies/{currency.Id.Value}", response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }

    private Task<IResult> GetCurrencies(
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var currencies = context.Currencies.AsEnumerable().ToList();
            var response = mapper.Map<List<GetCurrency>>(currencies);
            return Task.FromResult(Results.Ok(response));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Results.BadRequest(new { error = ex.Message }));
        }
    }

    private async Task<IResult> SetAsDefault(
        int id,
        IApplicationDbContext context,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        try
        {
            var currencyId = CurrencyId.Create(id);

            var currencies = await context.Currencies.ToListAsync(cancellationToken);

            foreach (var currency in currencies)
            {
                currency.SetAsDefault(currencyId);
            }

            await context.SaveChangesAsync(cancellationToken);
            
            var response = mapper.Map<List<GetCurrency>>(currencies);
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }

    private async Task<IResult> DeleteCurrency(
        int id,
        IApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        try
        {
            var currency = await context.Currencies.FirstOrDefaultAsync(c => c.Id.Value == id, cancellationToken);
            
            if (currency == null)
            {
                return Results.NotFound(new { error = "Currency not found" });
            }

            context.Currencies.Remove(currency);
            await context.SaveChangesAsync(cancellationToken);

            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }
}
