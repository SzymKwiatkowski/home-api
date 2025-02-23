using HomeApi.Domain.Entities.Incomes;
using HomeApi.Domain.Entities.Summaries;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities;

public class Summary : BaseAuditableEntity<SummaryId>
{
    private Summary() { }

    public Duration Duration { get; private set; } = null!;

    public Name Name { get; private set; } = null!;

    public Description? Description { get; private set; }

    private List<Income> _incomes { get; init; } = new List<Income>();

    private List<Payment> _payments { get; init; } = new List<Payment>();

    public Amount OverallAmount { get; private set; } = null!;

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

    public IReadOnlyList<Income> GetIncomes() => _incomes.ToList();

    public IReadOnlyList<Payment> GetPayments() => _payments.ToList();

    public void AddIncome(Income income)
    {
        _incomes.Add(income);
    }

    public void AddPayment(Payment payment)
    {
        _payments.Add(payment);
    }

    public void SetIncomes(ICollection<Income> incomes)
    {
        _incomes.Clear();
        _incomes.AddRange(incomes);
    }

    public void SetPayments(ICollection<Payment> payments)
    {
        _payments.Clear();

        _payments.AddRange(payments);
    }
}
