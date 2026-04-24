using HomeApi.Domain.Entities.Entries;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Entities.ApplicationUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minerals.StringCases;

namespace HomeApi.Infrastructure.Data.Configurations;

public class EntriesConfiguration : IEntityTypeConfiguration<Entry>
{
    public void Configure(EntityTypeBuilder<Entry> builder)
    {
        ConfigureEventsTable(builder);
        ConfigureEntriesUsers(builder);
    }

    private static void ConfigureEventsTable(EntityTypeBuilder<Entry> builder)
    {
        builder.ToTable("entries");
        builder.HasIndex(x => x.Id).IsUnique();

        builder.HasOne<EntryEntityKind>().WithMany().HasForeignKey(e => e.EntryEntityKindId);
    }

    private static void ConfigureEntriesUsers(EntityTypeBuilder<Entry> builder)
    {
        builder
            .HasMany<ApplicationUser>("_users")
            .WithMany()
            .UsingEntity(
                "entries_users",                
                r => r.HasOne(typeof(ApplicationUser)).WithMany().HasForeignKey("user_id"),
                l => l.HasOne(typeof(Entry)).WithMany().HasForeignKey(nameof(EntryId).ToSnakeCase()),
                j => j.HasKey(nameof(EntryId).ToSnakeCase(), "user_id")
            );
    }
}
