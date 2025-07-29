using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PM.Common.Application.Behaviors;

namespace PM.Common.Application.MediatRExtensions;

public static class MediatRExtensions
{
	public static IServiceCollection AddMediatRAndOpenBehaviors(this IServiceCollection services, Assembly assembly)
	{
		services.AddMediatR(config =>
		{
			config.RegisterServicesFromAssembly(assembly);

			config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
		});

		return services;
	}
}