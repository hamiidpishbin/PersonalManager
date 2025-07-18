using Microsoft.Extensions.DependencyInjection;

namespace PM.Identity.Application;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddMediatR(config =>
		{
			config.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly);
		});
		
		return services;
	}
}