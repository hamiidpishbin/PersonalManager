using PM.Common.Domain;

namespace PM.DTM.Domain.Events;

public class SprintTaskCreatedEvent(Guid sprintTaskId) : DomainEvent
{
	public Guid SprintTaskId { get; init; } = sprintTaskId;
}