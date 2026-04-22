using HomeApi.Domain.Entities.Entries;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Summaries;

public class Summary : BaseCalendarEntity<SummaryId>
{
    private Summary() { }

    private readonly List<Entry> _entries = new();

    public Duration Duration { get; private set; } = null!;

    public Amount? OverallAmount { get; private set; } = null!;

    public static Summary Create(
        Name name,
        Duration duration,
        Description? description = null,
        SummaryId? id = null
    )
    {
        return new Summary
        {
            Id = id ?? SummaryId.New(),
            Name = name,
            Duration = duration,
            Description = description,
        };
    }

    public IReadOnlyList<Entry> GetEntries() => _entries.ToList();

    public void AddEntry(Entry entry)
    {
        if (_entries.Any(p => p.Id == entry.Id))
        {
            _entries.Add(entry);
        }
    }

    public void AddEntries(ICollection<Entry> entries)
    {
        entries.ToList().ForEach(AddEntry);
    }

    public void RemoveIncome(EntryId entryId)
    {
        var income = _entries.FirstOrDefault(p => p.Id == entryId);

        if (income is not null)
        {
            _entries.Remove(income);
        }
    }

    public void RemoveIncomes(ICollection<EntryId> entryIds)
    {
        entryIds.ToList().ForEach(RemoveIncome);
    }


    public void SetIncomes(ICollection<Entry> entries)
    {
        _entries.Clear();
        _entries.AddRange(entries);
    }
}
