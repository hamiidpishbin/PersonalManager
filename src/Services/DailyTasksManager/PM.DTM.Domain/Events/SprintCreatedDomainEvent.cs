using Common.Messaging;

namespace PM.DTM.Domain.Events;

public record SprintCreatedDomainEvent(Guid SprintId) : IDomainEvent;