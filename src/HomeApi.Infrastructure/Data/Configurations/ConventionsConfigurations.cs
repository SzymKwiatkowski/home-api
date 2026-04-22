using HomeApi.Domain.Common;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeApi.Infrastructure.Data.Configurations;

public static class ConventionsConfigurations
{
    internal class DateTimeOffsetToTimestampConverter : ValueConverter<DateTimeOffset, long>
    {
        public DateTimeOffsetToTimestampConverter()
            : base(v => v.ToUnixTimeMilliseconds(), v => DateTimeOffset.FromUnixTimeMilliseconds(v)) { }
    }
    
    internal class EntryKindConverter : ValueConverter<EntryKind, int>
    {
        public EntryKindConverter()
            : base(v => v.Value, v => EntryKind.FromValue(v)) { }
    }
    
    internal class NameConverter : ValueConverter<Name, string>
    {
        public NameConverter()
            : base(v => v.Value, v => Name.Create(v)) { }
    }
    
    internal class DescriptionConverter : ValueConverter<Description?, string?>
    {
        public DescriptionConverter()
            : base(v => v == null ? null : v.Value, v => v == null ? null : Description.Create(v)) { }
    }

    internal class OccuredAtOnUtcConverter : ValueConverter<OccuredAtOnUtc, DateTimeOffset>
    {
        public OccuredAtOnUtcConverter()
            : base(v => v.Value, v => OccuredAtOnUtc.Create(v)) { }
    }
    
    internal class IsActiveConverter : ValueConverter<IsActive, bool>
    {
        public IsActiveConverter()
            : base(v => v.Value, v => IsActive.Create(v)) { }
    }

    internal class IsCompletedConverter : ValueConverter<IsCompleted, bool>
    {
        public IsCompletedConverter()
            : base(v => v.Value, v => IsCompleted.Create(v)) { }
    }
    
    internal class PeriodDefinitionConverter : ValueConverter<PeriodDefinition?, string?>
    {
        public PeriodDefinitionConverter()
            : base(v => v == null ? null : v.Value, v => v == null ? null : PeriodDefinition.Create(v))
        { }
    }
    
    internal class AmountConverter : ValueConverter<Amount, decimal>
    {
        public AmountConverter()
            : base(v => v.Value, v => Amount.Create(v)) { }
    }
    
    internal class StronglyTypedIdConnverter<TId, TValue> : ValueConverter<TId, TValue>
        where TId : IEntityId<TValue>, ICreateId<TId, TValue>
        where TValue : notnull
    {
        public StronglyTypedIdConnverter()
            : base(v => v.Value, v => StronglyTypedId<TId, TValue>.Create(v)) { }
    }

}
