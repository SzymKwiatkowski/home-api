using Ardalis.SmartEnum;

namespace HomeApi.Domain.Enums;

public class EntryKind : SmartEnum<EntryKind>
{
    public static EntryKind Payment => new EntryKind(nameof(Payment), 1);

    public static EntryKind Income => new EntryKind(nameof(Income), 2);

    public static EntryKind Event => new EntryKind(nameof(Event), 3);

    private EntryKind(string name, int value)
        : base(name, value) { }
}
