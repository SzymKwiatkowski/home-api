using HomeApi.Domain.Entities;
using HomeApi.Domain.Entities.Currencies;
using HomeApi.Domain.Entities.EventKinds;
using HomeApi.Domain.Entities.Events;
using HomeApi.Domain.Entities.IncomeKinds;
using HomeApi.Domain.Entities.Incomes;
using HomeApi.Domain.Entities.PaymentKinds;
using HomeApi.Domain.Entities.Payments;
using HomeApi.Domain.Entities.Summaries;

namespace HomeApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Summary> Summaries { get; }

    DbSet<Payment> Payments { get; }

    DbSet<Income> Incomes { get; }

    DbSet<Currency> Currencies { get; }

    DbSet<Event> Events { get; }

    DbSet<EventKind> EventKinds { get; }

    DbSet<IncomeKind> IncomeKinds { get; }

    DbSet<PaymentKind> PaymentKinds { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
