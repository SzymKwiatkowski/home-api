using System.ComponentModel.DataAnnotations.Schema;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.PeriodicEntries;

public class PeriodicEntry: BaseAuditableEntity<PeriodicEntryId>
{
    public Duration Duration { get; private set; } = null!;

    public OccuredAtOnUtc? OccuredAtOnUtc {get; private set;} = null!;

    public PeriodDefinition PeriodDefinition { get; private set; } = null!;

    public Name Name { get; private set; } = null!;

    public Description? Description { get; private set; } = null!;

    public Amount? Amount {get; private set;} = null;

    protected readonly List<string> _userIds = new();
    
    [NotMapped]
    public IReadOnlyList<string> UserIds => _userIds;

    public static PeriodicEntry Create(
        Duration duration,
        PeriodDefinition periodDefinition,
        Name name,
        Description? description,
        Amount? amount,
        List<string> userIds
    )
    {
        var entry =  new PeriodicEntry
        {
            Duration = duration,
            PeriodDefinition = periodDefinition,
            Name = name,
            Description = description,
            Amount = amount,
        };

        entry.SetUserIds(userIds);

        return entry;
    }

    public void SetUserIds(List<string> userIds)
    {
        _userIds.Clear();
        _userIds.AddRange(userIds);
    }
}