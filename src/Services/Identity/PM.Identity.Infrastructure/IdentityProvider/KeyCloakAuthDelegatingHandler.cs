using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PM.Identity.Infrastructure.IdentityProvider;

internal sealed class KeyCloakAuthDelegatingHandler(IOptions<KeyCloakOptions> options, ILogger<KeyCloakAuthDelegatingHandler> logger) : DelegatingHandler
{
	private readonly KeyCloakOptions _options = options.Value;

	protected override async Task<HttpResponseMessage> SendAsync(
		HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		var authToken = await GetAuthorizationToken(cancellationToken);

		if (authToken is null)
		{
			const string authTokenError = "Auth token cannot be null when registering a user";
			
			logger.LogError(authTokenError);
			
			throw new InvalidOperationException(authTokenError);
		}

		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken.AccessToken);

		var httpResponseMessage = await base.SendAsync(request, cancellationToken);

		if (httpResponseMessage.IsSuccessStatusCode) return httpResponseMessage;
		
		var error = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
		
		logger.LogError("Error in sending user register request to KeyCloak: {Error}", error);

		throw new Exception($"Error in sending user register request to KeyCloak: {error}");
	}

	private async Task<AuthToken?> GetAuthorizationToken(CancellationToken cancellationToken)
	{
		var authRequestParameters = new KeyValuePair<string, string>[]
		{
			new("client_id", _options.ConfidentialClientId),
			new("client_secret", _options.ConfidentialClientSecret),
			new("scope", "openid"),
			new("grant_type", "client_credentials")
		};

		using var authRequestContent = new FormUrlEncodedContent(authRequestParameters);

		using var authRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(_options.TokenUrl));

		authRequest.Content = authRequestContent;

		using var authorizationResponse = await base.SendAsync(authRequest, cancellationToken);
		
		if (!authorizationResponse.IsSuccessStatusCode)
		{
			var error = await authorizationResponse.Content.ReadAsStringAsync(cancellationToken);
			
			logger.LogError("Error in Getting Authorization Token: {Error}", error);

			throw new Exception($"Error in Getting Authorization Token: {error}");
		}
		
		return await authorizationResponse.Content.ReadFromJsonAsync<AuthToken>(cancellationToken);
	}

	internal sealed class AuthToken
	{
		[JsonPropertyName("access_token")]
		public string AccessToken { get; init; }
	}
}