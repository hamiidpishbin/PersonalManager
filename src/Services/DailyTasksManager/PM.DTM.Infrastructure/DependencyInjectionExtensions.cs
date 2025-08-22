using Microsoft.Extensions.DependencyInjection;
using PM.DTM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PM.DTM.Infrastructure;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<DTMDbContext>(options =>
		{
			options.UseNpgsql(configuration.GetConnectionString("Database"));
		});
		
		return services;
	}
}