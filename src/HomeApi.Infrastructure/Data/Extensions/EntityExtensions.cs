using HomeApi.Domain.Common;
using HomeApi.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeApi.Infrastructure.Data.Extensions;

public static class EntityExtensions
{
    public static void ApplyEntityIdValueConverters(ModelBuilder modelBuilder)
    {
        // List of all EF Core objects and properties that are mapped to the db
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entityType
                .ClrType.GetProperties()
                .Where(p => typeof(IStronglyTypedId).IsAssignableFrom(p.PropertyType) &&
                            p.PropertyType.BaseType != null);

            foreach (var property in properties)
            {
                var converterType = typeof(ConventionsConfigurations.StronglyTypedIdConnverter<,>).MakeGenericType(
                    property.PropertyType,
                    // Should always be inherited from StronglyTypedId
                    property.PropertyType.BaseType!.GetGenericArguments().Last()
                );

                var converter = Activator.CreateInstance(converterType);
                if (converter is null)
                {
                    throw new Exception(
                        "Error creating EntityIdValueConverter Object: "
                            + entityType.ClrType.ToString()
                            + " Property: "
                            + property.ToString()
                    );
                }
                modelBuilder
                    .Entity(entityType.Name)
                    .Property(property.Name)
                    .HasConversion((ValueConverter)converter);
            }
        }
    }
}
