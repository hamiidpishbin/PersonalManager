using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Identity.Domain.Users;

namespace PM.Identity.Infrastructure.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{

	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(u => u.Id);

		builder.Property(u => u.FirstName).HasMaxLength(200);

		builder.Property(u => u.LastName).HasMaxLength(200);

		builder.Property(u => u.Email).HasMaxLength(300);

		builder.HasIndex(u => u.Email).IsUnique();

		// builder.HasIndex(u => u.IdentityId).IsUnique();
	}
}