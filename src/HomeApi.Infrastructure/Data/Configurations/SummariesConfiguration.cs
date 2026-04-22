using HomeApi.Domain.Entities.Entries;
using HomeApi.Domain.Entities.Summaries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeApi.Infrastructure.Data.Configurations;

public class SummariesConfiguration : IEntityTypeConfiguration<Summary>
{
    public void Configure(EntityTypeBuilder<Summary> builder)
    {
        ConfigureSummariesTable(builder);
    }

    private static void ConfigureSummariesTable(EntityTypeBuilder<Summary> builder)
    {
        builder.ToTable("summaries");
        builder.HasIndex(x => x.Id).IsUnique();

        builder
            .HasMany<Entry>("_entries")
            .WithMany()
            .UsingEntity(
                "summaries_entries",
                j =>
                {
                    j.ToTable("summaries_entries");
                    j.HasOne(typeof(Summary)).WithMany().HasForeignKey(nameof(SummaryId));
                    j.HasOne(typeof(Entry)).WithMany().HasForeignKey(nameof(EntryId));
                    j.HasKey(nameof(SummaryId), nameof(EntryId));
                });

        builder.ComplexProperty(x => x.Duration);
    }
}
