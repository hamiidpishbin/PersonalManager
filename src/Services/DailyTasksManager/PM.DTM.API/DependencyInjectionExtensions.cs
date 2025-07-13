using PM.Common.Presentation;

namespace PM.DTM.API;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddPresentationServices(this IServiceCollection services)
	{
		services.AddCommonPresentationServices();

		return services;
	}
}