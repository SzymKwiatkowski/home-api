using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using Throw;

namespace HomeApi.Domain.Entities.EntryEntityKinds;

public class EntryEntityKind : BaseAuditableEntity<EntryEntityKindId>
{
    private EntryEntityKind() { }

    public Name Name { get; private set; } = null!;

    public EntryKind EntryKind { get; private set; } = null!;

    public Emoji Emoji { get; private set; } = null!;

    public Color Color { get; private set; } = null!;

    public static EntryEntityKind Create(
        Name name,
        EntryKind entryKind,
        Emoji emoji,
        Color color,
        EntryEntityKindId? id = null)
    {
        name.ThrowIfNull();
        entryKind.ThrowIfNull();

        var idGen = id ?? EntryEntityKindId.New();
        
        if (entryKind == EntryKind.Expense)
        {
            idGen.Value.Throw().IfLessThan<short>(1).IfGreaterThan<short>(400);
        }
        
        if (entryKind == EntryKind.Income)
        {
            idGen.Value.Throw().IfLessThan<short>(401).IfGreaterThan<short>(800);
        }
        
        if (entryKind == EntryKind.Event)
        {
            idGen.Value.Throw().IfLessThan<short>(801).IfGreaterThan<short>(1200);
        }

        return new EntryEntityKind
        {
            Id = idGen,
            Name = name,
            EntryKind = entryKind,
            Emoji =  emoji,
            Color =  color
        };
    }
}
