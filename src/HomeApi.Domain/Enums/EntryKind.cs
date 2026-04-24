using Ardalis.SmartEnum;

namespace HomeApi.Domain.Enums;

public class EntryKind : SmartEnum<EntryKind>
{
    public static readonly EntryKind None = new EntryKind(nameof(None), 0);
    
    public static readonly EntryKind Expense = new EntryKind(nameof(Expense), 1);

    public static readonly EntryKind Income = new EntryKind(nameof(Income), 2);

    public static readonly EntryKind Event = new EntryKind(nameof(Event), 3);

    private EntryKind(string name, int value)
        : base(name, value) { }
}
