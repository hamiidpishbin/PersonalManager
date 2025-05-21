using Microsoft.Extensions.DependencyInjection;

namespace PM.Identity.Application;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		return services;
	}
}