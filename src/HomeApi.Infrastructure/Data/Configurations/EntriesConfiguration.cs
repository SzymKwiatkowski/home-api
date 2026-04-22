using HomeApi.Domain.Entities.ApplicationUser;
using HomeApi.Domain.Entities.Entries;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minerals.StringCases;

namespace HomeApi.Infrastructure.Data.Configurations;

public class EntriesConfiguration : IEntityTypeConfiguration<Entry>
{
    public void Configure(EntityTypeBuilder<Entry> builder)
    {
        ConfigureEventsTable(builder);
        ConfigureEventsOwners(builder);
    }

    private static void ConfigureEventsTable(EntityTypeBuilder<Entry> builder)
    {
        builder.ToTable("entries");
        builder.HasIndex(x => x.Id).IsUnique();

        builder.ComplexProperty(x => x.Duration);
        builder.HasOne<EntryEntityKind>().WithMany().HasForeignKey(e => e.EntryEntityKindId);
    }

    private static void ConfigureEventsOwners(EntityTypeBuilder<Entry> builder)
    {
        builder
            .HasMany("_owners")
            .WithMany()
            .UsingEntity(
                "owners_events",
                l => l.HasOne(typeof(ApplicationUser)).WithMany().HasForeignKey("user_id"),
                r => r.HasOne(typeof(Entry)).WithMany().HasForeignKey(nameof(EntryId).ToSnakeCase()),
                j => j.HasKey(nameof(EntryId).ToSnakeCase(), "user_id")
            );
    }
}
