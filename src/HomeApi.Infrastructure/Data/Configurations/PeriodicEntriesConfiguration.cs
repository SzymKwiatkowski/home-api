using HomeApi.Domain.Entities.PeriodicEntries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeApi.Infrastructure.Data.Configurations;

public class PeriodicEntriesConfiguration : IEntityTypeConfiguration<PeriodicEntry>
{
    public void Configure(EntityTypeBuilder<PeriodicEntry> builder)
    {
        ConfigurePeriodicEntriesTable(builder);
    }

    private void ConfigurePeriodicEntriesTable(EntityTypeBuilder<PeriodicEntry> builder)
    {
        builder.ToTable("periodic_entries");
        builder.HasIndex(x => x.Id).IsUnique();

        builder.ComplexProperty(x => x.Duration);
    }
}
