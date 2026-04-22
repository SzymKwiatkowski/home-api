using System.ComponentModel.DataAnnotations.Schema;
using HomeApi.Domain.Entities.ApplicationUsers;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Enums;
using HomeApi.Domain.Extensions;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Entries;

public class Entry : BaseCalendarEntity<EntryId>
{
    public Amount? Amount { get; protected set; } = null!;
    
    public EntryEntityKindId? EntryEntityKindId { get; protected set; } = null!;
    
    public EntryKind EntryKind { get; protected set; } = null!;

    protected readonly List<ApplicationUser> _users = new();
    
    [NotMapped]
    public IReadOnlyList<ApplicationUser> Users => _users;

    public IsCompleted IsCompleted { get; protected set; } = null!;

    public static Entry Create(
        Name name,
        Amount? amount,
        OccuredAtOnUtc occuredAtOnUtc,
        EntryId? id = null
    )
    {
        GuardExtensions.Null(name, occuredAtOnUtc);

        var entry = new Entry
        {
            Id = id ?? EntryId.New(),
            Name = name,
            Amount = amount,
            OccuredAtOnUtc = occuredAtOnUtc,
            EntryKind = MapKindBasedOnAmount(amount),
            Description = null,
            IsCompleted = IsCompleted.False,
        };

        return entry;
    }

    public static Entry Create(
        Name name,
        Amount? amount,
        OccuredAtOnUtc occuredAtOnUtc,
        List<string> userIds,
        Description? description = null,
        EntryEntityKindId? entryEntityKindId = null,
        EntryKind? entryKind = null,
        EntryId? id = null
    )
    {
        GuardExtensions.Null(name, occuredAtOnUtc);

        var entry = new Entry
        {
            Id = id ?? EntryId.New(),
            Name = name,
            Amount = amount,
            OccuredAtOnUtc = occuredAtOnUtc,
            EntryKind = entryKind ?? MapKindBasedOnAmount(amount),
            Description = description,
            EntryEntityKindId = entryEntityKindId,
            IsCompleted = IsCompleted.False,
        };

        entry._users.AddRange(userIds.Select(id => new ApplicationUser { Id = id }));

        return entry;
    }

    public void AddUser(string userId)
    {
        if (!string.IsNullOrEmpty(userId) && !_users.Contains(new ApplicationUser { Id = userId }))
        {
            _users.Add(new ApplicationUser { Id = userId });
        }
    }

    public void SetDescription(Description? description)
    {
        Description = description;
    }

    public void SetEntryEntityKind(EntryEntityKindId? entryEntityKindId)
    {
        EntryEntityKindId = entryEntityKindId;
    }

    public void SetEntryKind(EntryKind entryKind)
    {
        EntryKind = entryKind;
    }

    public void ToggleCompletion()
    {
        IsCompleted = IsCompleted.Value ? IsCompleted.False : IsCompleted.True;
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
