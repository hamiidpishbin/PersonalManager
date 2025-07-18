using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json;

namespace PM.Common.Presentation.Auth;

public class KeycloakClaimsTransformer : IClaimsTransformation
{
	public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
	{
		var identity = (ClaimsIdentity?)principal.Identity;

		// Avoid adding roles multiple times
		if (identity == null || identity.HasClaim("transformed", "true")) return Task.FromResult(principal);

		var resourceAccessClaim = identity.FindFirst("resource_access")?.Value;

		if (!string.IsNullOrEmpty(resourceAccessClaim))
		{
			using var doc = JsonDocument.Parse(resourceAccessClaim);
			
			if (doc.RootElement.TryGetProperty("pm-confidential-client", out var clientAccess))
			{
				if (clientAccess.TryGetProperty("roles", out var roles))
				{
					foreach (var role in roles.EnumerateArray())
					{
						var roleValue = role.GetString();
						
						if (!string.IsNullOrEmpty(roleValue))
						{
							identity.AddClaim(new Claim(ClaimTypes.Role, roleValue));
						}
					}
				}
			}
		}

		// Prevent duplicate transformation
		identity.AddClaim(new Claim("transformed", "true"));

		return Task.FromResult(principal);
	}
}
