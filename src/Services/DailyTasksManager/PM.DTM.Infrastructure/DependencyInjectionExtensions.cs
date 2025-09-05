using Microsoft.Extensions.DependencyInjection;
using PM.DTM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PM.Common.Infrastructure;
using PM.Common.Infrastructure.Interceptors;
using PM.DTM.Application.Abstractions.Data;
using PM.DTM.Application.Abstractions.Repositories;
using PM.DTM.Infrastructure.Data.Repositories;

namespace PM.DTM.Infrastructure;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCommonInfrastructureServices(configuration);
		
		services.AddDbContext<DTMDbContext>((sp, options) =>
		{
			var auditInterceptor = sp.GetRequiredService<AuditInterceptor>();

			options
				.UseNpgsql(configuration.GetConnectionString("Database"))
				.AddInterceptors(auditInterceptor);
		});

		services.AddScoped<IWorkItemRepository, WorkItemRepository>();
		services.AddScoped<ISprintRepository, SprintRepository>();
		services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<DTMDbContext>());
		
		return services;
	}
}