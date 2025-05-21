using Microsoft.Extensions.DependencyInjection;

namespace PM.Identity.Infrastructure;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
	{
		return services;
	}
}