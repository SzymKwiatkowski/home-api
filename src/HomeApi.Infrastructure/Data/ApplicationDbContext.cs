using System.Reflection;
using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.Entities.ApplicationUsers;
using HomeApi.Domain.Entities.Currencies;
using HomeApi.Domain.Entities.Entries;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Entities.PeriodicEntries;
using HomeApi.Domain.Entities.Summaries;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using HomeApi.Infrastructure.Data.Configurations;
using HomeApi.Infrastructure.Data.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeApi.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public const string Schema = "home_app";

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Entry> Entries => Set<Entry>();

    public DbSet<Summary> Summaries => Set<Summary>();

    public DbSet<Currency> Currencies => Set<Currency>();

    public DbSet<EntryEntityKind> EntryEntityKinds => Set<EntryEntityKind>();

    public DbSet<PeriodicEntry> PeriodicEntries => Set<PeriodicEntry>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.HasDefaultSchema(Schema);

        EntityExtensions.ApplyEntityIdValueConverters(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<ConventionsConfigurations.DateTimeOffsetToTimestampConverter>();

        configurationBuilder.Properties<OccuredAtOnUtc>().HaveConversion<ConventionsConfigurations.OccuredAtOnUtcConverter>();
        configurationBuilder.Properties<EntryKind>().HaveConversion<ConventionsConfigurations.EntryKindConverter>();
        configurationBuilder.Properties<Name>().HaveConversion<ConventionsConfigurations.NameConverter>();
        configurationBuilder.Properties<Description?>().HaveConversion<ConventionsConfigurations.DescriptionConverter>();
        configurationBuilder.Properties<IsActive>().HaveConversion<ConventionsConfigurations.IsActiveConverter>();
        configurationBuilder.Properties<IsCompleted>().HaveConversion<ConventionsConfigurations.IsCompletedConverter>();
        configurationBuilder
            .Properties<PeriodDefinition?>()
            .HaveConversion<ConventionsConfigurations.PeriodDefinitionConverter>();
        configurationBuilder.Properties<Amount>().HaveConversion<ConventionsConfigurations.AmountConverter>();
    }
}
