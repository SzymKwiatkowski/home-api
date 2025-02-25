using HomeApi.Domain.Entities;
using HomeApi.Domain.Entities.ApplicationUser;
using HomeApi.Domain.Entities.PaymentKinds;
using HomeApi.Domain.Entities.Payments;
using HomeApi.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeApi.Infrastructure.Data.Configurations;

public class PaymentsConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        ConfigurePaymentsTable(builder);
        ConfigureCalendarEventProperties(builder);
    }

    private static void ConfigurePaymentsTable(EntityTypeBuilder<Payment> builder)
    {
        // Payment specific configuration
        builder.HasIndex(e => e.Id).IsUnique();

        builder.HasOne<PaymentKind>().WithMany().HasForeignKey(e => e.PaymentKindId);
    }

    private static void ConfigureCalendarEventProperties(EntityTypeBuilder<Payment> builder)
    {
        // Base configuration
        builder.ComplexProperty(p => p.Duration);

        builder
            .HasMany<ApplicationUser>("_owners")
            .WithMany()
            .UsingEntity(
                "owners_payments",
                l => l.HasOne(typeof(ApplicationUser)).WithMany().HasForeignKey("user_id"),
                r => r.HasOne(typeof(Payment)).WithMany().HasForeignKey("payment_id"),
                j => j.HasKey("payment_id", "user_id")
            );
    }
}
