using PM.Common.Presentation.Endpoints;

namespace PM.Identity.Presentation;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddPresentationServices(this IServiceCollection services)
	{
		services.AddEndpointsFromAssembly(AssemblyReference.Assembly);
		
		return services;
	}
}