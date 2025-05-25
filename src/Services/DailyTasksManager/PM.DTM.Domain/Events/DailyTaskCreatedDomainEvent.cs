using PM.Common.Domain;

namespace PM.DTM.Domain.Events;

public class DailyTaskCreatedDomainEvent(Guid dailyTaskId) : DomainEvent
{
	public Guid DailyTaskId { get; init; } = dailyTaskId;
}