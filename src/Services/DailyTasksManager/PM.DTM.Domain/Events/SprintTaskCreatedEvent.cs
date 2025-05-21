using Common.Messaging;

namespace PM.DTM.Domain.Events;

public record SprintTaskCreatedEvent(Guid SprintTaskId) : IDomainEvent;