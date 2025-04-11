using Common.Messaging;
using MediatR;

namespace DTM.Domain.Sprints.Events;

public record SprintCreatedDomainEvent(Guid SprintId) : IDomainEvent;