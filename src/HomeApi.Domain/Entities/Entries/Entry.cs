using System.ComponentModel.DataAnnotations.Schema;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Enums;
using HomeApi.Domain.Extensions;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Entries;

public class Entry : BaseCalendarEntity<EntryId>
{
    public Amount Amount { get; private set; } = null!;
    
    public EntryEntityKindId? EntryEntityKindId { get; private set; } = null!;
    
    public EntryKind EntryKind { get; private set; } = null!;

    public Duration? Duration { get; private set; } = null!;

    protected readonly List<string> _userIds = new();
    
    [NotMapped]
    public IReadOnlyList<string> UserIds => _userIds;

    public static Entry Create(
        Name name,
        SeverityKind severity,
        Amount amount,
        OccuredAtOnUtc occuredAtOnUtc,
        EntryId? id = null
    )
    {
        GuardExtensions.Null(name, severity, amount, occuredAtOnUtc);

        var entry = new Entry
        {
            Id = id ?? EntryId.New(),
            Name = name,
            Severity = severity,
            Amount = amount,
            OccuredAtOnUtc = occuredAtOnUtc,
            EntryKind = MapKindBasedOnAmount(amount),
            Description = null,
        };

        return entry;
    }

    private static EntryKind MapKindBasedOnAmount(Amount? amount)
    {
        return amount?.Value switch
        {
            null => EntryKind.Event,
            > 0 => EntryKind.Income,
            < 0 => EntryKind.Payment,
            _ => throw new ArgumentException("Amount cannot be zero for an entry.")
        };
    }
}
