using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using PM.Common.Application.MediatRExtensions;

namespace PM.DTM.Application.Extensions;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddValidatorsFromAssembly(typeof(DependencyInjectionExtensions).Assembly, includeInternalTypes: true);

		services.AddMediatRAndOpenBehaviors(typeof(DependencyInjectionExtensions).Assembly);
		
		return services;
	}
}