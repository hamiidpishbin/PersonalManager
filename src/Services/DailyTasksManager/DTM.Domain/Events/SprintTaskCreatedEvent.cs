using Common.Messaging;

namespace DTM.Domain.SprintTasks.Events;

public record SprintTaskCreatedEvent(Guid SprintTaskId) : IDomainEvent;