using PM.Common.Domain;

namespace PM.Identity.Application.IdentityProvider;

public interface IIdentityProviderService
{
	Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
}