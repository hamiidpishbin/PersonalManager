using Microsoft.EntityFrameworkCore;
using PM.Identity.Application.Abstractions.Data;
using PM.Identity.Domain.Users;

namespace PM.Identity.Infrastructure.Data;

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
{
	public DbSet<User> Users { get; set; }

	override protected void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDbContext).Assembly);
	}
}