using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace PM.Common.Infrastructure.Logging;

public static class LoggingExtensions
{
	public static IHostBuilder UseCustomSerilog(this IHostBuilder builder)
	{
		return builder.UseSerilog((context, services, configuration) =>
		{
			var elasticsearchUri = context.Configuration["Elasticsearch:Uri"];
			var applicationName = context.Configuration["ApplicationName"] ?? 
			                      context.HostingEnvironment.ApplicationName;

			configuration
				.ReadFrom.Configuration(context.Configuration)
				.ReadFrom.Services(services)
				.Enrich.FromLogContext()
				.Enrich.WithMachineName()
				.Enrich.WithExceptionDetails()
				.Enrich.WithProperty("ApplicationName", applicationName)
				.Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
				.WriteTo.Console();

			if (!string.IsNullOrEmpty(elasticsearchUri))
			{
				configuration.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearchUri))
				{
					IndexFormat = $"{applicationName}-logs-{context.HostingEnvironment.EnvironmentName.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
					AutoRegisterTemplate = true,
					NumberOfShards = 2,
					NumberOfReplicas = 1
				});
			}
		});
	}

	public static IServiceCollection AddCustomLogging(this IServiceCollection services, IConfiguration configuration)
	{
		return services;
	}
}