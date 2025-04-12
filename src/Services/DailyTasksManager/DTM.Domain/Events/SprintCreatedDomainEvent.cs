using Common.Messaging;

namespace DTM.Domain.Events;

public record SprintCreatedDomainEvent(Guid SprintId) : IDomainEvent;