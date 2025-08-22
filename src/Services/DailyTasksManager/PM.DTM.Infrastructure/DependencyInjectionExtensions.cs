using Microsoft.Extensions.DependencyInjection;
using PM.DTM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PM.Common.Infrastructure;

namespace PM.DTM.Infrastructure;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCommonInfrastructureServices(configuration);
		
		services.AddDbContext<DTMDbContext>(options =>
		{
			options.UseNpgsql(configuration.GetConnectionString("Database"));
		});
		
		return services;
	}
}