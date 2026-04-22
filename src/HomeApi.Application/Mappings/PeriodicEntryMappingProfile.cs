using HomeApi.Domain.Entities.PeriodicEntries;
using HomeApi.Rest.Contracts.PeriodicEntries;

namespace HomeApi.Application.Mappings;

public class PeriodicEntryMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PeriodicEntry, GetPeriodicEntry>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.OccuredAtOnUtc, src => src.OccuredAtOnUtc == null ? (DateTime?)null : src.OccuredAtOnUtc.Value.DateTime)
            .Map(dest => dest.PeriodDefinition, src => src.PeriodDefinition.Value)
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.Amount, src => src.Amount == null ? (decimal?)null : (decimal?)src.Amount.Value)
            .Map(dest => dest.IsActive, src => src.IsActive.Value)
            .Map(dest => dest.UserIds, src => src.UserIds.ToList());
    }
}
