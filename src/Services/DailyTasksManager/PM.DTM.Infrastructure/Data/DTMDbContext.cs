using Microsoft.EntityFrameworkCore;
using PM.Common.Infrastructure.Converters;
using PM.DTM.Application.Abstractions.Data;
using PM.DTM.Domain.Models.WorkItems;

namespace PM.DTM.Infrastructure.Data;

public class DTMDbContext(DbContextOptions<DTMDbContext> options) : DbContext(options), IUnitOfWork
{
	public DbSet<WorkItem> WorkItems { get; set; }

	override protected void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(DTMDbContext).Assembly);
		
		ApplyDateTimeConverters(modelBuilder);

		base.OnModelCreating(modelBuilder);
	}
	
	private static void ApplyDateTimeConverters(ModelBuilder modelBuilder)
	{
		foreach (var entityType in modelBuilder.Model.GetEntityTypes())
		{
			foreach (var property in entityType.GetProperties())
			{
				if (property.ClrType == typeof(DateTime))
				{
					property.SetValueConverter(new UtcDateTimeConverter());
				}
				else if (property.ClrType == typeof(DateTime?))
				{
					property.SetValueConverter(new UtcNullableDateTimeConverter());
				}
			}
		}
	}
}