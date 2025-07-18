using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace PM.Common.Presentation.Auth;

public static class AuthExtensions
{
    public static IServiceCollection AddCustomAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptionsConfig>()
                         ?? throw new InvalidOperationException("JwtOptions section is missing or malformed.");
 
        services.AddScoped<IClaimsTransformation, KeycloakClaimsTransformer>();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = jwtOptions.Authority;
                options.Audience = jwtOptions.Audience;
                options.RequireHttpsMetadata = jwtOptions.RequireHttpsMetadata;
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtOptions.TokenValidationParameters.ValidateIssuer,
                    ValidIssuer = jwtOptions.TokenValidationParameters.ValidIssuer,
                    ValidateAudience = jwtOptions.TokenValidationParameters.ValidateAudience,
                    ValidAudience = jwtOptions.TokenValidationParameters.ValidAudience
                };
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