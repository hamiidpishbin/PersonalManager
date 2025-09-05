using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PM.Common.Presentation.Middlewares;

namespace PM.Common.Presentation;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddCommonPresentationServices(this IServiceCollection services)
	{
		services.AddScoped<TraceIdMiddleware>();
		
		return services;
	}

	public static WebApplication UseCommonPresentationServices(this WebApplication app)
	{
		app.UseMiddleware<TraceIdMiddleware>();
		
		return app;
	}
}