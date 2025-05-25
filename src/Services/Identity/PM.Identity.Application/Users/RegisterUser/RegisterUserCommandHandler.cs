using PM.Common.Application.Messaging;
using PM.Common.Domain;

namespace PM.Identity.Application.Users.RegisterUser;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{

	public Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}