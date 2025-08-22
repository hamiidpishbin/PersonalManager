using Microsoft.EntityFrameworkCore;
using PM.DTM.Infrastructure.Data;

namespace PM.DTM.Presentation.Extensions;

public static class MigrationExtensions
{
	public static void ApplyMigrations(this IApplicationBuilder app)
	{
		using var scope = app.ApplicationServices.CreateScope();

		using var dbContext = scope.ServiceProvider.GetRequiredService<DTMDbContext>();

		dbContext.Database.Migrate();
	}
}