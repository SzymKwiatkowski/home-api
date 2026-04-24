using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Rest.Contracts.EntryEntityKinds;

namespace HomeApi.Application.Mappings;

public class EntryEntityKindMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EntryEntityKind, GetEntryEntityKind>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.EntryKind, src => src.EntryKind.Value)
            .Map(dest => dest.Color,  src => src.Color.Value)
            .Map(dest => dest.Icon, src => src.Emoji.Value);
    }
}
