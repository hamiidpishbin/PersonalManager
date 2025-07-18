using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PM.Common.Infrastructure.Logging;

namespace PM.Common.Infrastructure;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddCommonInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCustomLogging(configuration);
        
		return services;
	}
}