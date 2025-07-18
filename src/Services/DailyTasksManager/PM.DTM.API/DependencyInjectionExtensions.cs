using PM.Common.Presentation.Auth;
using PM.Common.Presentation.Endpoints;

namespace PM.DTM.API;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddPresentationServices(this IServiceCollection services)
	{
		services.AddCustomAuthServices();
		
		services.AddEndpointsFromAssembly(AssemblyReference.Assembly);

		return services;
	}
}