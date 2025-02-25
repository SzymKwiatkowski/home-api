using HomeApi.Domain.Entities.Currencies;
using HomeApi.Domain.Entities.Currencies.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeApi.Infrastructure.Data.Configurations;

public class CurrenciesConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        ConfigureCurrenciesTable(builder);   
    }

    private static void ConfigureCurrenciesTable(EntityTypeBuilder<Currency> builder)
    {
        builder.HasIndex(e => e.Id).IsUnique();

        builder
            .Property(x => x.Code)
            .HasConversion(
                code => code.Value,
                value => Code.Create(value));

        builder
            .Property(x => x.Symbol)
            .HasConversion(
                symbol => symbol.Value,
                value => Symbol.Create(value));
    }
}
