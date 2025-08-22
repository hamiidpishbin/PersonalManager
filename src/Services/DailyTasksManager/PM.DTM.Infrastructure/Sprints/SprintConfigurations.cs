using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.DTM.Domain.Models.Sprints;

namespace PM.DTM.Infrastructure.Sprints;

public class SprintConfigurations : IEntityTypeConfiguration<Sprint>
{

	public void Configure(EntityTypeBuilder<Sprint> builder)
	{
		builder
			.Property(t => t.Name)
			.IsRequired();
		
		builder
			.Property(t => t.StartDate)
			.IsRequired();
		
		builder
			.Property(t => t.EndDate)
			.IsRequired();
	}
}