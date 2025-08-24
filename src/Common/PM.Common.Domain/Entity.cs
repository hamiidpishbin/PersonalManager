namespace PM.Common.Domain;

public abstract class Entity<TId>
{
	public required TId Id { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
	
	private readonly List<IDomainEvent> _domainEvents = [];
	
	public IReadOnlyList<IDomainEvent> GetDomainEvents()
	{
		return _domainEvents.ToList();
	}

	public void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

	public void RaiseDomainEvent(IDomainEvent domainEvent)
	{
		_domainEvents.Add(domainEvent); 
	}
}

public abstract class Entity : Entity<Guid> 
{

}