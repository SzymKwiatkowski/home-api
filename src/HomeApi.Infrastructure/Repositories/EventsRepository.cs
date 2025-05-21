using HomeApi.Application.Repositories;
using HomeApi.Domain.Entities.Events;
using HomeApi.Infrastructure.Data;

namespace HomeApi.Infrastructure.Repositories;

public class EventsRepository(ApplicationDbContext applicationDbContext) 
    : Repository<EventId, Event>(applicationDbContext), IEventsRepository
{

}
