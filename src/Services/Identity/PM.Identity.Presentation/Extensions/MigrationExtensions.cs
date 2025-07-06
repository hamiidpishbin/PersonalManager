using Microsoft.EntityFrameworkCore;
using PM.Identity.Infrastructure.Data;

namespace PM.Identity.Presentation.Extensions;

public static class MigrationExtensions
{
	public static void ApplyMigrations(this IApplicationBuilder app)
	{
		using var scope = app.ApplicationServices.CreateScope();
		
		using var context = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
		
		context.Database.Migrate();
	}
}