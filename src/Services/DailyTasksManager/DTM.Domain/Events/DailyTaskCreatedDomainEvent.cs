using Common.Messaging;

namespace DTM.Domain.Events;

public record DailyTaskCreatedDomainEvent(Guid DailyTaskId) : IDomainEvent;