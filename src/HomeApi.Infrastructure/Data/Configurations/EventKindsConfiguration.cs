using HomeApi.Domain.Entities.EventKinds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeApi.Infrastructure.Data.Configurations;

public class EventKindsConfiguration : IEntityTypeConfiguration<EventKind>
{
    public void Configure(EntityTypeBuilder<EventKind> builder)
    {
        builder.HasIndex(x => x.Id).IsUnique();
    }
}
