using HomeApi.Domain.Enums;
using HomeApi.Domain.ValueObjects;
using Throw;

namespace HomeApi.Domain.Entities.EntryEntityKinds;

public class EntryEntityKind : BaseAuditableEntity<EntryEntityKindId>
{
    private EntryEntityKind() { }

    public Name Name { get; private set; } = null!;

    public EntryKind EntryKind { get; private set; } = null!;

    public static EntryEntityKind Create(Name name, EntryKind entryKind, EntryEntityKindId? id = null)
    {
        name.ThrowIfNull();
        entryKind.ThrowIfNull();

        return new EntryEntityKind
        {
            Id = id ?? EntryEntityKindId.New(),
            Name = name,
            EntryKind = entryKind,
        };
    }
}
