using Microsoft.EntityFrameworkCore;
using PM.DTM.Domain.Models.WorkItems;

namespace PM.DTM.Infrastructure.Data;

public class DTMDbContext(DbContextOptions<DTMDbContext> options) : DbContext(options)
{
	public DbSet<WorkItem> WorkItems { get; set; }

	override protected void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(DTMDbContext).Assembly);
		
		base.OnModelCreating(modelBuilder);
	}
}