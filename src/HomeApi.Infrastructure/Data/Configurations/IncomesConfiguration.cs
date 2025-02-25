using HomeApi.Domain.Entities.ApplicationUser;
using HomeApi.Domain.Entities.IncomeKinds;
using HomeApi.Domain.Entities.Incomes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minerals.StringCases;

namespace HomeApi.Infrastructure.Data.Configurations;

public class IncomesConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        ConfigureIncomesTable(builder);
        ConfigureCalendarEventProperties(builder);
    }

    private static void ConfigureIncomesTable(EntityTypeBuilder<Income> builder)
    {
        builder.HasIndex(e => e.Id).IsUnique();

        builder.HasOne<IncomeKind>().WithMany().HasForeignKey(e => e.IncomeKindId);
    }

    private static void ConfigureCalendarEventProperties(EntityTypeBuilder<Income> builder)
    {
        builder.ComplexProperty(p => p.Duration);

        builder
            .HasMany<ApplicationUser>("_owners")
            .WithMany()
            .UsingEntity(
                "owners_incomes",
                l => l.HasOne(typeof(ApplicationUser)).WithMany().HasForeignKey("user_id"),
                r => r.HasOne(typeof(Income)).WithMany().HasForeignKey(nameof(IncomeId).ToSnakeCase()),
                j => j.HasKey(nameof(IncomeId).ToSnakeCase(), "user_id")
            );
    }
}
