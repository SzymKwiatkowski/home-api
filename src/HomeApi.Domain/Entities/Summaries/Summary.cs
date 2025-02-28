using HomeApi.Domain.Entities.Incomes;
using HomeApi.Domain.Entities.Payments;
using HomeApi.Domain.ValueObjects;

namespace HomeApi.Domain.Entities.Summaries;

public class Summary : BaseCalendarEntity<SummaryId>
{
    private Summary() { }

    private readonly List<Income> _incomes = new ();

    private readonly List<Payment> _payments = new();

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
        if (_incomes.Any(p => p.Id == income.Id))
        {
            _incomes.Add(income);
        }
    }

    public void AddIncomes(ICollection<Income> incomes)
    {
        incomes.ToList().ForEach(AddIncome);
    }

    public void AddPayments(ICollection<Payment> payments)
    {
        payments.ToList().ForEach(AddPayment);
    }

    public void AddPayment(Payment payment)
    {
        if (_payments.Any(p => p.Id == payment.Id))
        {
            _payments.Add(payment);
        }
    }

    public void RemoveIncome(IncomeId incomeId)
    {
        var income = _incomes.FirstOrDefault(p => p.Id == incomeId);

        if (income is not null)
        {
            _incomes.Remove(income);
        }
    }

    public void RemoveIncomes(ICollection<IncomeId> incomeIds)
    {
        incomeIds.ToList().ForEach(RemoveIncome);
    }

    public void RemovePayment(PaymentId paymentId)
    {
        var payment = _payments.FirstOrDefault(p => p.Id == paymentId);

        if (payment is not null)
        {
            _payments.Remove(payment);
        }
    }

    public void RemovePayments(ICollection<PaymentId> paymentIds)
    {
        paymentIds.ToList().ForEach(RemovePayment);
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
