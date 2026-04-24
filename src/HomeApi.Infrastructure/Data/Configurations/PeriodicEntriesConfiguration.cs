using HomeApi.Domain.Entities.ApplicationUsers;
using HomeApi.Domain.Entities.PeriodicEntries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minerals.StringCases;

namespace HomeApi.Infrastructure.Data.Configurations;

public class PeriodicEntriesConfiguration : IEntityTypeConfiguration<PeriodicEntry>
{
    public void Configure(EntityTypeBuilder<PeriodicEntry> builder)
    {
        ConfigurePeriodicEntriesTable(builder);
        ConfigurePeriodicEntriesUsers(builder);
    }

    private void ConfigurePeriodicEntriesTable(EntityTypeBuilder<PeriodicEntry> builder)
    {
        builder.ToTable("periodic_entries");
        builder.HasIndex(x => x.Id).IsUnique();

        builder.ComplexProperty(x => x.Duration);
    }
    
    private static void ConfigurePeriodicEntriesUsers(EntityTypeBuilder<PeriodicEntry> builder)
    {
        builder
            .HasMany("_users")
            .WithMany()
            .UsingEntity(
                "periodic_entries_users",                
                r => r.HasOne(typeof(ApplicationUser)).WithMany().HasForeignKey("user_id"),
                l => l.HasOne(typeof(PeriodicEntry)).WithMany().HasForeignKey(nameof(PeriodicEntryId).ToSnakeCase()),
                j => j.HasKey(nameof(PeriodicEntryId).ToSnakeCase(), "user_id")
            );
    }
}
