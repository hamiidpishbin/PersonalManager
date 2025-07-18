using PM.Common.Application.Messaging;
using PM.Common.Domain;
using PM.Identity.Application.IdentityProvider;
using PM.Identity.Infrastructure.IdentityProvider;

namespace PM.Identity.Application.Users.LoginUser;

public class LoginUserQueryHandler(
	IIdentityProviderService identityProviderService) : IQueryHandler<LoginUserQuery, UserToken>
{
	public async Task<Result<UserToken>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
	{
		var userTokenRequest = new UserTokenRequest(request.Username, request.Password);

		var userTokenResponse = await identityProviderService.LoginAsync(userTokenRequest, cancellationToken);

		return GetUserToken(userTokenResponse.Value);
	}

	private UserToken GetUserToken(UserTokenResponse response)
	{
		return new UserToken(response.AccessToken, response.RefreshToken);
	}
}