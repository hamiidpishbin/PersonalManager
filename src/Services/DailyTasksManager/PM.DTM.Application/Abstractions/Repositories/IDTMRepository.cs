using System.Linq.Expressions;
using PM.Common.Domain;

namespace PM.DTM.Application.Abstractions.Repositories;

public interface IDTMRepository<TEntity, in TId> 
	where TEntity : Entity<TId>
	where TId : struct
{
	Task<TEntity?> FindAsync(TId id, CancellationToken cancellationToken = default);
	Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking, CancellationToken cancellationToken = default);
	Task<TEntity?> GetByIdAsync(TId id, bool asNoTracking = false, CancellationToken cancellationToken = default);
	Task<TEntity?> GetByIdAsNoTrackingAsync(TId id, CancellationToken cancellationToken = default);
	Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
	void Update(TEntity entity);
	void Delete(TEntity entity);
}

public interface IDTMRepository<TEntity> : IDTMRepository<TEntity, Guid> where TEntity : Entity<Guid>; 