using PM.Common.Domain;

namespace PM.DTM.Domain.Events;

public record SprintTaskCreatedEvent(Guid SprintTaskId) : IDomainEvent;