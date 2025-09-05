using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PM.Common.Domain;
using PM.DTM.Application.Abstractions.Repositories;

namespace PM.DTM.Infrastructure.Data.Repositories;

public abstract class DTMRepository<TEntity, TId>(DTMDbContext dbContext) 
	: IDTMRepository<TEntity, TId>
	where TEntity : Entity<TId>
	where TId : struct
{
	protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
	
	public async Task<TEntity?> FindAsync(TId id, CancellationToken cancellationToken = default)
	{
		return await _dbSet.FindAsync(id, cancellationToken);
	}
	
	public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate,  bool asNoTracking, CancellationToken cancellationToken = default)
	{
		var query = asNoTracking
			? _dbSet.AsNoTracking()
			: _dbSet;

		return query.Where(predicate).ToListAsync(cancellationToken);
	}
	
	public async Task<TEntity?> GetByIdAsync(TId id, bool asNoTracking = false, CancellationToken cancellationToken = default)
	{
		var query = asNoTracking
			? _dbSet.AsNoTracking()
			: _dbSet;

		return await query.FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
	}
	
	public async Task<TEntity?> GetByIdAsNoTrackingAsync(TId id, CancellationToken cancellationToken = default)
	{
		return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
	}
	
	public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
	{
		await _dbSet.AddAsync(entity, cancellationToken);
	}
	
	public void Update(TEntity entity)
	{
		_dbSet.Update(entity);
	}
	
	public void Delete(TEntity entity)
	{
		_dbSet.Remove(entity);
	}
}

public abstract class DTMRepository<TEntity>(DTMDbContext dbContext) 
	: DTMRepository<TEntity, Guid>(dbContext)
	where TEntity : Entity<Guid>
{
	
}