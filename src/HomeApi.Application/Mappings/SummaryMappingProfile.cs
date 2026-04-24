using HomeApi.Domain.Entities.Summaries;
using HomeApi.Rest.Contracts.Summaries;

namespace HomeApi.Application.Mappings;

public class SummaryMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Summary, GetSummary>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name.Value)
            .Map(dest => dest.Description, src => src.Description != null ? src.Description.Value : null)
            .Map(dest => dest.StartTime, src => src.Duration.Start.DateTime)
            .Map(dest => dest.EndTime, src => src.Duration.End.HasValue ? src.Duration.End.Value.DateTime : DateTime.MinValue)
            .Map(dest => dest.OverallAmount, src => src.OverallAmount != null ? (decimal?)src.OverallAmount.Value : null);
    }
}
