using Common.Messaging;

namespace DTM.Domain.DailyTasks.Events;

public record DailyTaskCreatedDomainEvent(Guid DailyTaskId) : IDomainEvent;