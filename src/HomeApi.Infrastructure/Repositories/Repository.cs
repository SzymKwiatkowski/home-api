using CSharpFunctionalExtensions;
using HomeApi.Application.Common.Interfaces;
using HomeApi.Domain.Common;
using HomeApi.Infrastructure.Data;

namespace HomeApi.Infrastructure.Repositories;

public abstract class Repository<TId, TEntity> : IRepository<TId, TEntity>
where TEntity : BaseAuditableEntity<TId>
where TId : IStronglyTypedId
{
    private readonly ApplicationDbContext _dbContext;
    private bool _disposed = false;

    protected Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Result> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(new object[] {id}, cancellationToken);

        if (entity == null)
        {
            return Result.Failure($"Entity with id {id} not found.");
        }

        _dbContext.Set<TEntity>().Remove(entity);

        return Result.Success();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }
        
    }

    public async Task<Result<bool>> ExistsAsync(TId id, CancellationToken cancellationToken)
    {
        var exists = (await _dbContext.Set<TEntity>().FindAsync(new object[] {id}, cancellationToken)) != null;

        return Result.Success(exists);
    }

    public Task<Result<IEnumerable<TEntity>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = _dbContext.Set<TEntity>().AsEnumerable();

        return Task.FromResult(Result.Success(entities));
    }

    public async Task<Result<TEntity>> GetByIdAsync(TId id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(id);

        if (entity == null)
        {
            return Result.Failure<TEntity>($"Entity with id {id} not found.");
        }

        return Result.Success(entity);
    }

    public Task<Result> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<TEntity>().Update(entity);

        return Task.FromResult(Result.Success());
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
