using HomeApi.Rest.Contracts.Entries;
using Entry = HomeApi.Domain.Entities.Entries.Entry;

namespace HomeApi.Application.Mappings;

public class EntryMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entry, GetEntry>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.UserIds, src => src.UserIds)
            .Map(dest => dest.Description, 
                src => src.Description == null ? null : src.Description.Value)
            .Map(dest => dest.EntryKind, src => src.EntryKind.Value)
            .Map(dest => dest.Amount, 
                src => src.Amount == null ? null : (decimal?)src.Amount.Value)
            .Map(dest => dest.OccuredAtOnUtc, src => src.OccuredAtOnUtc.Value)
            .Map(dest => dest.EntryEntityKindId, src => src.EntryEntityKindId.Value);
    }
}
