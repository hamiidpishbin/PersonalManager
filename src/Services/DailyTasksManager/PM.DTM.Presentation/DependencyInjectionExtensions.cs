using PM.Common.Presentation;
using PM.Common.Presentation.Auth;
using PM.Common.Presentation.Endpoints;

namespace PM.DTM.Presentation;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCommonPresentationServices();
		
		services.AddCustomAuthServices(configuration);
		
		services.AddEndpointsFromAssembly(AssemblyReference.Assembly);

		return services;
	}

	public static WebApplication UsePresentationServices(this WebApplication app)
	{
		app.UseCommonPresentationServices();
		
		return app;
	}
}