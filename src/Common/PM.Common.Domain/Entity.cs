namespace PM.Common.Domain;

public abstract class Entity<TId>
{
	public TId Id { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
	public string? CreatedBy { get; set; }
	public string? UpdatedBy { get; set; }
	
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