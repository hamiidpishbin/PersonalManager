using MediatR;
using PM.Common.Domain;

namespace PM.Common.Application.Messaging;

public interface IDomainEventHandler<in TDomainEvent> 
	: INotificationHandler<TDomainEvent> 
	where TDomainEvent : IDomainEvent;