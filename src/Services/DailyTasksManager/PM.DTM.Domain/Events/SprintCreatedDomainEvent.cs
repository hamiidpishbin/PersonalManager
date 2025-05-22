using PM.Common.Domain;

namespace PM.DTM.Domain.Events;

public record SprintCreatedDomainEvent(Guid SprintId) : IDomainEvent;