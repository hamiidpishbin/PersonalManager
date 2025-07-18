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

                // ToDo: The two following events should be moved into a AuthExceptionLoggingMiddleware so it can be used in Register and Login APIs
                // Currently, the adding of app.UseAuthentication to the Program.cs of pm.identity has caused unhandled situations and they do not need to be there 
                // After that, should proceed with testing the addition of Docker environment in the other existing branch
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = (context) =>
                    {
                        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<JwtBearerEvents>>();
                        
                        logger.LogError(context.Exception, "Authentication failed for path {Path}. reason: {Message}",
                            context.Request.Path,
                            context.Exception.Message);
                        
                        return Task.CompletedTask;
                    },
                    OnChallenge = (context) =>
                    {
                        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<JwtBearerEvents>>();
                        
                        logger.LogError("Authentication failed for path {Path}. Error: {Error}. Decsription: {Description}", 
                            context.Request.Path,
                            context.Error,
                            context.ErrorDescription);
                        
                        return Task.CompletedTask;
                    }
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