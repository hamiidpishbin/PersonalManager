using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace PM.Common.Presentation.Endpoints;

public static class EndpointExtensions
{
	public static void AddEndpointsFromAssembly(this IServiceCollection services, Assembly assembly)
	{
		var serviceDescriptors = assembly.GetTypes()
			.Where(type => type is { IsAbstract: false, IsInterface: false }
			               && type.IsAssignableTo(typeof(IEndpoint)))
			.Select(type => ServiceDescriptor.Transient(service: typeof(IEndpoint), implementationType: type))
			.ToArray();
		
		services.TryAddEnumerable(serviceDescriptors);
	}

	public static IApplicationBuilder MapEndpoints(this WebApplication app)
	{
		var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

		foreach (var endpoint in endpoints)
		{
			endpoint.MapEndpoint(app);
		}

		return app;
	}
}