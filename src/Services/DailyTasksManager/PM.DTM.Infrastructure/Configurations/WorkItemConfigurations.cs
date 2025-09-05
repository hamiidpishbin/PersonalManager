using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.DTM.Domain.Models.WorkItems;

namespace PM.DTM.Infrastructure.Configurations;

public class WorkItemConfigurations : IEntityTypeConfiguration<WorkItem>
{

	public void Configure(EntityTypeBuilder<WorkItem> builder)
	{
		builder
			.HasMany(t => t.SubWorkItems)
			.WithOne(t => t.ParentWorkItem)
			.HasForeignKey(t => t.ParentWorkItemId)
			.IsRequired(false)
			.OnDelete(DeleteBehavior.Restrict);

		builder
			.HasOne(t => t.Sprint)
			.WithMany(t => t.WorkItems)
			.HasForeignKey(t => t.SprintId);

		builder
			.Property(t => t.SprintId)
			.IsRequired();

		builder
			.Property(t => t.UserId)
			.IsRequired();

		builder
			.Property(t => t.Name)
			.IsRequired();
		
		builder
			.Property(t => t.Priority)
			.IsRequired();
		
		builder
			.Property(t => t.Status)
			.IsRequired();
	}
}