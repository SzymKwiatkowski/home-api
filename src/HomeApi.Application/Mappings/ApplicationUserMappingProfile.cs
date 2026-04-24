using HomeApi.Domain.Entities.ApplicationUsers;
using HomeApi.Rest.Contracts.ApplicationUsers;

namespace HomeApi.Application.Mappings;

public class ApplicationUserMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApplicationUser, GetUser>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Email, src => src.Email);
    }
}
