using HomeApi.Application.Repositories;
using HomeApi.Domain.Entities.Entries;
using HomeApi.Infrastructure.Data;

namespace HomeApi.Infrastructure.Repositories;

public class EntriesRepository(ApplicationDbContext applicationDbContext) 
    : Repository<EntryId, Entry>(applicationDbContext), IEntriesRepository
{

}
