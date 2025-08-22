using Microsoft.Extensions.DependencyInjection;
using PM.Common.Application.Abstractions.Authentication;

namespace PM.Common.Application;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddCommonApplicationServices(this IServiceCollection services)
	{
		return services;
	}
}