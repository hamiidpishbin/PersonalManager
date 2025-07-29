using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace PM.Common.Presentation.Auth;

public static class AuthExtensions
{
    public static IServiceCollection AddCustomAuthServices(this IServiceCollection services)
    {
        services.AddScoped<IClaimsTransformation, KeycloakClaimsTransformer>();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "http://localhost:18080/realms/personalManager";
                options.Audience = "pm-confidential-client";
                options.RequireHttpsMetadata = false;
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "http://pm.keycloak:8080/realms/personalManager",
                    ValidateAudience = true,
                    ValidAudience = "pm-confidential-client"
                };
                options.EventsType = typeof(AuthExceptionLoggingEvents);
            });

        var authPolicyBuilder = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        
        services.AddAuthorizationBuilder()
            .SetDefaultPolicy(authPolicyBuilder)
            .AddPolicy("AdminOnly", policy => policy.RequireRole("admin"))
            .AddPolicy("UserOnly", policy => policy.RequireRole("user"));

        return services;
    }
}