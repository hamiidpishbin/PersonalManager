using Common.Messaging;

namespace DTM.Domain.Events;

public record SprintTaskCreatedEvent(Guid SprintTaskId) : IDomainEvent;