using System.Reflection;
using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.Entities.ApplicationUser;
using HomeApi.Domain.Entities.Currencies;
using HomeApi.Domain.Entities.EventKinds;
using HomeApi.Domain.Entities.Events;
using HomeApi.Domain.Entities.IncomeKinds;
using HomeApi.Domain.Entities.Incomes;
using HomeApi.Domain.Entities.PaymentKinds;
using HomeApi.Domain.Entities.Payments;
using HomeApi.Domain.Entities.Summaries;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using HomeApi.Infrastructure.Data.Configurations;
using HomeApi.Infrastructure.Data.Extensions;
using HomeApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeApi.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public const string Schema = "home_app";

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<Summary> Summaries => Set<Summary>();

    public DbSet<Income> Incomes => Set<Income>();

    public DbSet<Currency> Currencies => Set<Currency>();

    public DbSet<Event> Events => Set<Event>();

    public DbSet<EventKind> EventKinds => Set<EventKind>();

    public DbSet<IncomeKind> IncomeKinds => Set<IncomeKind>();

    public DbSet<PaymentKind> PaymentKinds => Set<PaymentKind>();

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

        configurationBuilder.Properties<SeverityKind>().HaveConversion<ConventionsConfigurations.SeverityKindConverter>();
        configurationBuilder.Properties<Name>().HaveConversion<ConventionsConfigurations.NameConverter>();
        configurationBuilder.Properties<Description?>().HaveConversion<ConventionsConfigurations.DescriptionConverter>();
        configurationBuilder.Properties<IsPeriodic>().HaveConversion<ConventionsConfigurations.IsPeriodicConverter>();
        configurationBuilder
            .Properties<PeriodDefinition?>()
            .HaveConversion<ConventionsConfigurations.PeriodDefinitionConverter>();
        configurationBuilder.Properties<Amount>().HaveConversion<ConventionsConfigurations.AmountConverter>();
    }
}
