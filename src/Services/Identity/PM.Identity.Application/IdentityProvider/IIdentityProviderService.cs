using PM.Common.Domain;
using PM.Identity.Infrastructure.IdentityProvider;

namespace PM.Identity.Application.IdentityProvider;

public interface IIdentityProviderService
{
	Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
	Task<Result<UserTokenResponse>> LoginAsync(UserTokenRequest request, CancellationToken cancellationToken = default);
}