using Common.Messaging;

namespace PM.DTM.Domain.Events;

public record DailyTaskCreatedDomainEvent(Guid DailyTaskId) : IDomainEvent;