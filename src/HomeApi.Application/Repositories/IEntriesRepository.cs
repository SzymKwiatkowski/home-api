using System;
using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.Entities.Entries;

namespace HomeApi.Application.Repositories;

public interface IEntriesRepository : IRepository<EntryId, Entry>
{

}
