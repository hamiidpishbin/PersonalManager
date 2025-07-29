using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PM.Common.Application.MediatRExtensions;

namespace PM.Identity.Application;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services, Assembly assembly)
	{
		services.AddMediatRAndOpenBehaviors(assembly);
		
		return services;
	}
}