using HomeApi.Domain.Entities.IncomeKinds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeApi.Infrastructure.Data.Configurations;

public class IncomeKindsConfiguration : IEntityTypeConfiguration<IncomeKind>
{
    public void Configure(EntityTypeBuilder<IncomeKind> builder)
    {
        builder.HasIndex(x => x.Id).IsUnique();
    }
}
