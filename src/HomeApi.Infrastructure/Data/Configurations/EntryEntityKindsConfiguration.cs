using HomeApi.Domain.Entities.EntryEntityKinds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeApi.Infrastructure.Data.Configurations;

public class EntryEntityKindsConfiguration : IEntityTypeConfiguration<EntryEntityKind>
{
    public void Configure(EntityTypeBuilder<EntryEntityKind> builder)
    {
        builder.HasIndex(x => x.Id).IsUnique();

        builder.ToTable("entry_entity_kinds");
        builder.Property(x => x.Id);
    }
}
