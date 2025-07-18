using System.Net;
using Microsoft.Extensions.Logging;
using PM.Common.Domain;
using PM.Identity.Application.IdentityProvider;

namespace PM.Identity.Infrastructure.IdentityProvider;

internal sealed class IdentityProviderService(
	KeyCloakRegisterClient registerClient,
	KeyCloakLoginClient loginClient,
	ILogger<IdentityProviderService> logger) : IIdentityProviderService
{
	private const string PasswordCredentialType = "Password";

	public async Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default)
	{
		var userRepresentation = new UserRepresentation(
			user.Email,
			user.Email,
			user.FirstName,
			user.LastName,
			true,
			true,
			[new CredentialRepresentation(PasswordCredentialType, user.Password, false)]
		);

		try
		{
			return await registerClient.RegisterUserAsync(userRepresentation, cancellationToken);
		}
		catch (HttpRequestException exception) when (exception.StatusCode == HttpStatusCode.Conflict)
		{
			logger.LogError(exception, "User registration failed.");

			return Result.Failure<string>(IdentityProviderErrors.EmailIsNotUnique);
		}
	}

	public async Task<Result<UserTokenResponse>> LoginAsync(UserTokenRequest request, CancellationToken cancellationToken = default)
	{
		var tokenRequest = new TokenRequest(request.Username, request.Password);
		
		return await loginClient.LoginAsync(tokenRequest, cancellationToken);
	}
}