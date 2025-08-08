using PM.Common.Application.Messaging;
using PM.Common.Domain;
using PM.Identity.Application.Abstractions.Data;
using PM.Identity.Application.IdentityProvider;
using PM.Identity.Domain.Users;

namespace PM.Identity.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler(
	IIdentityProviderService identityProviderService)
	: ICommandHandler<RegisterUserCommand, Guid>
{
	public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{
		var newUser = new UserModel(
			request.Email,
			request.Password,
			request.FirstName,
			request.LastName);
		
		var result = await identityProviderService.RegisterUserAsync(newUser, cancellationToken);
		
		return result.IsSuccess
			? Guid.Parse(result.Value)
			: Result.Failure<Guid>(result.Error);
	}
}