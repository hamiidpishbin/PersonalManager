using PM.Common.Domain;

namespace PM.Identity.Domain.Users;

public class UserRegisteredDomainEvent(Guid userId) : DomainEvent
{
	public Guid UserId { get; init; } = userId;
}