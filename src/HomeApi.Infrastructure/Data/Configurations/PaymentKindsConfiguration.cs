using HomeApi.Domain.Entities.PaymentKinds;
using HomeApi.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeApi.Infrastructure.Data.Configurations;

public class PaymentKindsConfiguration : IEntityTypeConfiguration<PaymentKind>
{
    public void Configure(EntityTypeBuilder<PaymentKind> builder)
    {
        builder.HasIndex(e => e.Id).IsUnique();
    }
}
