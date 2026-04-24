using System.ComponentModel.DataAnnotations.Schema;
using HomeApi.Domain.Entities.ApplicationUsers;
using HomeApi.Domain.Entities.Entries;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.PeriodicEntries;

public class PeriodicEntry : BaseAuditableEntity<PeriodicEntryId>
{
    public Duration Duration { get; private set; } = null!;

    public OccuredAtOnUtc? OccuredAtOnUtc {get; private set;} = null!;

    public PeriodDefinition PeriodDefinition { get; private set; } = null!;

    public Name Name { get; private set; } = null!;
    
    public EntryEntityKindId EntryEntityKindId { get; private set; } = EntryEntityKindId.New();

    public EntryKind EntryKind { get; private set; } = null!;
    
    public Description? Description { get; private set; } = null!;

    public Amount? Amount {get; private set;} = null;

    public IsActive IsActive { get; private set; } = null!;

    private readonly List<ApplicationUser> _users = new();
    
    [NotMapped]
    public IReadOnlyList<string> UserIds => _users.Select(u => u.Id).ToList();

    public static PeriodicEntry Create(
        Duration duration,
        PeriodDefinition periodDefinition,
        Name name,
        Description? description,
        Amount? amount,
        List<ApplicationUser> users,
        IsActive isActive,
        EntryKind entryKind,
        EntryEntityKindId  entryEntityKindId,
        PeriodicEntryId? periodicEntryId = null
    )
    {
        var entry = new PeriodicEntry
        {
            Duration = duration,
            PeriodDefinition = periodDefinition,
            Name = name,
            Description = description,
            Amount = amount,
            IsActive = isActive,
            EntryEntityKindId =  entryEntityKindId,
            EntryKind = entryKind,
            Id = periodicEntryId ?? PeriodicEntryId.New()
        };

        entry.SetUserIds(users);

        return entry;
    }
    
    public void Update(
        Duration? duration,
        PeriodDefinition? periodDefinition,
        Name? name,
        Description? description,
        Amount? amount,
        List<ApplicationUser> userIds,
        IsActive? isActive,
        EntryKind? entryKind,
        EntryEntityKindId?  entryEntityKindId
    )
    {
        Duration = duration ?? Duration;
        PeriodDefinition = periodDefinition ?? PeriodDefinition;
        Name = name ?? Name;
        Description = description ?? Description;
        Amount = amount ?? Amount;
        IsActive = isActive ?? IsActive;
        EntryEntityKindId = entryEntityKindId ?? EntryEntityKindId.New();

        EntryKind = entryKind ?? EntryKind;

        SetUserIds(userIds);
    }

    public void ToggleIsActive()
    {
        IsActive = IsActive.Create(!IsActive.Value);
    }
        

    public void SetUserIds(List<ApplicationUser> users)
    {
        _users.Clear();
        _users.AddRange(users);
    }
}
