using HomeApi.Domain.Entities.ApplicationUsers;
using HomeApi.Domain.Entities.Currencies;
using HomeApi.Domain.Entities.Entries;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Entities.PeriodicEntries;
using HomeApi.Domain.Entities.Summaries;

namespace HomeApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Summary> Summaries { get; }

    DbSet<Entry> Entries { get; }

    DbSet<EntryEntityKind> EntryEntityKinds { get; }

    DbSet<Currency> Currencies { get; }

    DbSet<PeriodicEntry> PeriodicEntries { get; }
    
    DbSet<ApplicationUser> ApplicationUsers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
