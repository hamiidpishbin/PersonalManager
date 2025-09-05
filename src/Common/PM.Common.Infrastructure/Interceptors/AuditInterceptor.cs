using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PM.Common.Application.Abstractions.Authentication;
using PM.Common.Domain;

namespace PM.Common.Infrastructure.Interceptors;

public class AuditInterceptor(IUserContext userContext) : SaveChangesInterceptor
{
	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		ApplyAuditing(eventData.Context);
		
		return base.SavingChanges(eventData, result);
	}

	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
	{
		ApplyAuditing(eventData.Context);
		
		return base.SavingChangesAsync(eventData, result, cancellationToken);
	}

	private void ApplyAuditing(DbContext? dbContext)
	{
		if (dbContext is null) return;

		foreach (var entry in dbContext.ChangeTracker.Entries<Entity>())
		{
			if (entry.State == EntityState.Added)
			{
				FillCreateProperties(entry);
				FillUpdateProperties(entry);
			}
			
			else if (entry.State == EntityState.Modified)
			{
				FillUpdateProperties(entry);
			}

		}
	}
	
	private void FillUpdateProperties(EntityEntry<Entity> entry)
	{
		entry.Entity.UpdatedAt = DateTime.UtcNow;
		entry.Entity.UpdatedBy = userContext.UserId.ToString();
	}
	
	private void FillCreateProperties(EntityEntry<Entity> entry)
	{
		entry.Entity.CreatedAt = DateTime.UtcNow;
		entry.Entity.CreatedBy = userContext.UserId.ToString();
	}
}