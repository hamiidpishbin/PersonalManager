using System.Text.Json.Serialization;

namespace PM.Identity.Infrastructure.IdentityProvider;

public record UserTokenResponse
{
	[JsonPropertyName("access_token")]
	public required string AccessToken { get; set; }
	[JsonPropertyName("refresh_token")]
	public required string RefreshToken { get; set; }
}