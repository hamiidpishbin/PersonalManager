using MediatR;

namespace PM.Common.Domain;

public interface IDomainEvent : INotification
{
	Guid Id { get; }
	DateTime OccurredOnUtc { get; }
}