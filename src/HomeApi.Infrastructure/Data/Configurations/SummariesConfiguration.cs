using HomeApi.Domain.Entities.Incomes;
using HomeApi.Domain.Entities.Payments;
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
            .HasMany<Income>("_incomes")
            .WithMany()
            .UsingEntity(
                "summaries_incomes",
                j =>
                {
                    j.ToTable("summaries_incomes");
                    j.HasOne(typeof(Summary)).WithMany().HasForeignKey(nameof(SummaryId));
                    j.HasOne(typeof(Income)).WithMany().HasForeignKey(nameof(IncomeId));
                    j.HasKey(nameof(SummaryId), nameof(IncomeId));
                });

        builder
            .HasMany<Payment>("_payments")
            .WithMany()
            .UsingEntity(
                "summaries_payments",
                j =>
                {
                    j.ToTable("summaries_payments");
                    j.HasOne(typeof(Summary)).WithMany().HasForeignKey(nameof(SummaryId));
                    j.HasOne(typeof(Payment)).WithMany().HasForeignKey(nameof(PaymentId));
                    j.HasKey(nameof(SummaryId), nameof(PaymentId));
                });

        builder.ComplexProperty(x => x.Duration);
    }
}
