using HomeApi.Domain.Entities.Entries;
using HomeApi.Rest.Contracts.Entries;
using Entry = HomeApi.Domain.Entities.Entries.Entry;
using EntryContract = HomeApi.Rest.Contracts.Entries.GetEntry;

namespace HomeApi.Application.Mappings;

public class EntryMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entry, EntryContract>()
            .Map(dest => dest.EventKind, src => (int)src.EntryKind)
            .Map(dest => dest.Amount, src => src.Amount == null ? null : (decimal?)src.Amount.Value)
            .Map(dest => dest.OccuredAtOnUtc, src => src.OccuredAtOnUtc == null ? null : (DateTimeOffset?)src.OccuredAtOnUtc.Value)
            .Map(dest => dest.EntryEntityKindId, src => src.EntryEntityKindId == null ? null : (int?)src.EntryEntityKindId.Value);
    }
}
