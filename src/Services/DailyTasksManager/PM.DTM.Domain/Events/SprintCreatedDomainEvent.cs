using PM.Common.Domain;

namespace PM.DTM.Domain.Events;

public class SprintCreatedDomainEvent(Guid sprintId) : DomainEvent
{
	public Guid SprintId { get; init; } = sprintId;
}