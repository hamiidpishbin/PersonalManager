using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PM.Identity.Application.Abstractions.Data;
using PM.Identity.Application.IdentityProvider;
using PM.Identity.Domain.Users;
using PM.Identity.Infrastructure.Data;
using PM.Identity.Infrastructure.IdentityProvider;
using PM.Identity.Infrastructure.Users;

namespace PM.Identity.Infrastructure;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<KeyCloakOptions>(configuration.GetSection("KeyCloak"));
		
		services.AddTransient<KeyCloakAuthDelegatingHandler>();

		services
			.AddHttpClient<KeyCloakClient>((serviceProvider, httpClient) =>
			{
				var keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeyCloakOptions>>().Value;

				httpClient.BaseAddress = new Uri(keycloakOptions.AdminUrl);
			})
			.AddHttpMessageHandler<KeyCloakAuthDelegatingHandler>();

		services.AddHttpClient<KeyCloakLoginClient>();

		services.AddTransient<IIdentityProviderService, IdentityProviderService>();
		
		services.AddDbContext<UsersDbContext>(options =>
		{
			options.UseNpgsql(configuration.GetConnectionString("Database")!);
		});

		services.AddScoped<IUserRepository, UserRepository>();

		services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UsersDbContext>());
		
		return services;
	}
}