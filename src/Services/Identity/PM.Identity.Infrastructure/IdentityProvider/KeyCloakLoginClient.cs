using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PM.Identity.Infrastructure.IdentityProvider;

internal class KeyCloakLoginClient(
	HttpClient httpClient,
	IOptions<KeyCloakOptions> options,
	ILogger<KeyCloakLoginClient> logger)
{
	private readonly KeyCloakOptions _keyCloakOptions = options.Value;
	
	public async Task<UserTokenResponse> LoginAsync(TokenRequest request, CancellationToken cancellationToken)
	{
		var requestParameters = new KeyValuePair<string, string>[]
		{
			new("client_id", _keyCloakOptions.PublicClientId),
			new("scope", "email openid"),
			new("username", request.Username),
			new("password", request.Password),
			new("grant_type", "password")
		};
		
		logger.LogInformation(_keyCloakOptions.PublicClientId);
		logger.LogInformation(_keyCloakOptions.TokenUrl);
		logger.LogInformation(request.Username);
		logger.LogInformation(request.Password);

		using var urlEncodedRequestParameters = new FormUrlEncodedContent(requestParameters);

		using var httpRequest = new HttpRequestMessage(HttpMethod.Post, _keyCloakOptions.TokenUrl);

		httpRequest.Content = urlEncodedRequestParameters;

		var response = await httpClient.SendAsync(httpRequest, cancellationToken);

		if (response.IsSuccessStatusCode)
		{
			return await response.Content.ReadFromJsonAsync<UserTokenResponse>(cancellationToken);
		}
		
		var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

		throw new HttpRequestException(responseBody);
	}
}