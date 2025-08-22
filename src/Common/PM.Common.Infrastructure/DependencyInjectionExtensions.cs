using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PM.Common.Application.Abstractions.Authentication;
using PM.Common.Infrastructure.Authentication;
using PM.Common.Infrastructure.Logging;

namespace PM.Common.Infrastructure;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddCommonInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCustomLogging(configuration);

		services.AddHttpContextAccessor();
		
		services.AddScoped<IUserContext, UserContext>();
		
		return services;
	}
}