using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;

namespace PM.Common.Presentation.Auth;

public class AuthExceptionLoggingEvents : JwtBearerEvents
{
	public AuthExceptionLoggingEvents(ILogger<AuthExceptionLoggingEvents> logger)
	{
		OnAuthenticationFailed = context =>
		{
			logger.LogError(context.Exception, 
				"Authentication failed for path {Path}. Reason: {Message}",
				context.Request.Path,
				context.Exception.Message);
			return Task.CompletedTask;
		};

		OnChallenge = context =>
		{
			logger.LogError("Authentication challenge failed for path {Path}. Error: {Error}. Description: {Description}",
				context.Request.Path,
				context.Error,
				context.ErrorDescription);
			return Task.CompletedTask;
		};
	}
}
