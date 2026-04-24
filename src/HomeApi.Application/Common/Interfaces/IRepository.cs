using CSharpFunctionalExtensions;
using HomeApi.Domain.Common;

namespace HomeApi.Application.Common.Interfaces;

public interface IRepository<TId, TEntity> : IDisposable
    where TEntity : BaseAuditableEntity<TId>
    where TId : IStronglyTypedId
{
    Task<Result<TEntity>> GetByIdAsync(TId id, CancellationToken cancellationToken);
    Task<Result<IEnumerable<TEntity>>> GetAllAsync(CancellationToken cancellationToken);
    Task<Result> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<Result> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<Result> DeleteAsync(TId id, CancellationToken cancellationToken);
    Task<Result<bool>> ExistsAsync(TId id, CancellationToken cancellationToken);
}
