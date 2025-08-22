using PM.Common.Domain;
using PM.DTM.Domain.Enums;
using PM.DTM.Domain.Models.Sprints;

namespace PM.DTM.Domain.Models.WorkItems;

public sealed class WorkItem : Entity
{
	public string Name { get; set; }
	public Guid SprintId { get; set; }
	public Guid? ParentWorkItemId { get; set; }
	public Guid UserId { get; set; }
	public Priority Priority { get; set; } = Priority.Low;
	public Status Status { get; set; } = Status.ToDo;
	public Sprint Sprint { get; set; }
	public WorkItem? ParentWorkItem { get; set; }
	public List<WorkItem> SubWorkItems { get; set; } = [];
}