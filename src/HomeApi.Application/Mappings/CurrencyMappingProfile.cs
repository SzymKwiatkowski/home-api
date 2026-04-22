using HomeApi.Domain.Entities.Currencies;
using HomeApi.Rest.Contracts.Currencies;

namespace HomeApi.Application.Mappings;

public class CurrencyMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Currency, GetCurrency>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.Code, src => src.Code.Value)
            .Map(dest => dest.Symbol, src => src.Symbol.Value);
    }
}
