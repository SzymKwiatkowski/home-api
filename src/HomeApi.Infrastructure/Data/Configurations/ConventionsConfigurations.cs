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
    
    internal class SeverityKindConverter : ValueConverter<SeverityKind, int>
    {
        public SeverityKindConverter()
            : base(v => v.Value, v => SeverityKind.FromValue(v)) { }
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
    
    internal class IsPeriodicConverter : ValueConverter<IsPeriodic, bool>
    {
        public IsPeriodicConverter()
            : base(v => v.Value, v => IsPeriodic.Create(v)) { }
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
