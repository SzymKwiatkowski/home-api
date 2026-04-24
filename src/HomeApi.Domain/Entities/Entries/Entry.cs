using System.ComponentModel.DataAnnotations.Schema;
using HomeApi.Domain.Entities.ApplicationUsers;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Enums;
using HomeApi.Domain.Extensions;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Entries;

public class Entry : BaseCalendarEntity<EntryId>
{
    public Amount? Amount { get; private set; } = null!;
    
    public EntryEntityKindId EntryEntityKindId { get; private set; } = null!;
    
    public EntryKind EntryKind { get; private set; } = null!;

    private readonly List<ApplicationUser> _users = new();
    
    [NotMapped]
    public IReadOnlyList<string> UserIds => _users.Select(u => u.Id).ToList();

    public IsCompleted IsCompleted { get; private set; } = null!;

    public static Entry Create(
        Name name,
        Amount? amount,
        OccuredAtOnUtc occuredAtOnUtc,
        List<ApplicationUser> users,
        EntryEntityKindId entryEntityKindId,
        IsCompleted isCompleted,
        EntryKind entryKind,
        Description? description = null,
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
            EntryKind = entryKind,
            Description = description,
            EntryEntityKindId = entryEntityKindId,
            IsCompleted = isCompleted,
        };

        foreach (var user in users)
        {
            entry.AddUser(user);
        }

        return entry;
    }

    public void AddUser(ApplicationUser user)
    {
        if (_users.Any(x => x.Id == user.Id))
        {
            return;
        }
        
        _users.Add(user);
    }

    public void SetUsers(List<ApplicationUser> users)
    {
        _users.Clear();

        foreach (var user in users)
        {
            AddUser(user);
        }
    }

    public void SetDescription(Description? description)
    {
        Description = description;
    }

    public void SetEntryEntityKind(EntryEntityKindId entryEntityKindId)
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
}
