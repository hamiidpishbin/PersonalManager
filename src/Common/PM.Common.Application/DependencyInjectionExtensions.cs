using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PM.Common.Application.Abstractions.Authentication;
using PM.Common.Application.MediatRExtensions;

namespace PM.Common.Application;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddCommonApplicationServices(this IServiceCollection services, Assembly assembly)
	{
		services.AddMediatRAndOpenBehaviors(assembly);
		
		services.AddValidatorsFromAssembly(typeof(DependencyInjectionExtensions).Assembly, includeInternalTypes: true);
		
		return services;
	}
}