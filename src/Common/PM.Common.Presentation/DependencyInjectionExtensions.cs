using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace PM.Common.Presentation;

public static class DependencyInjectionExtensions
{
	public static void AddCommonPresentationServices(this IServiceCollection services)
	{
		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.Authority = "http://localhost:18080/realms/personalManager";
				options.Audience = "pm-confidential-identity";
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = true,
					RoleClaimType = "roles" // Keycloak puts roles in this claim
				};
			});

		services.AddAuthorizationBuilder()
			.SetDefaultPolicy(new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.Build())
			.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"))
      .AddPolicy("UserOnly", policy => policy.RequireRole("user"));
	}
}