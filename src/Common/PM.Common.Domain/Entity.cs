namespace PM.Common.Domain;

public abstract class Entity()
{ 
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