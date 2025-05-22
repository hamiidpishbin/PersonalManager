using PM.Common.Domain;

namespace PM.DTM.Domain.Events;

public record DailyTaskCreatedDomainEvent(Guid DailyTaskId) : IDomainEvent;