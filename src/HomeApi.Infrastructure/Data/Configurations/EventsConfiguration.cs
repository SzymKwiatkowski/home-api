using HomeApi.Domain.Entities.ApplicationUser;
using HomeApi.Domain.Entities.EventKinds;
using HomeApi.Domain.Entities.Events;
using HomeApi.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minerals.StringCases;

namespace HomeApi.Infrastructure.Data.Configurations;

public class EventsConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        ConfigureEventsTable(builder);
        ConfigureEventsOwners(builder);
    }

    private static void ConfigureEventsTable(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("events");
        builder.HasIndex(x => x.Id).IsUnique();

        builder.ComplexProperty(x => x.Duration);
        builder.HasOne<EventKind>().WithMany().HasForeignKey(e => e.EventKindId);
    }

    private static void ConfigureEventsOwners(EntityTypeBuilder<Event> builder)
    {
        builder
            .HasMany("_owners")
            .WithMany()
            .UsingEntity(
                "owners_events",
                l => l.HasOne(typeof(ApplicationUser)).WithMany().HasForeignKey("user_id"),
                r => r.HasOne(typeof(Event)).WithMany().HasForeignKey(nameof(EventId).ToSnakeCase()),
                j => j.HasKey(nameof(EventId).ToSnakeCase(), "user_id")
            );
    }
}
