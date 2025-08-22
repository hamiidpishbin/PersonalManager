using PM.Common.Domain;
using PM.DTM.Domain.Models.WorkItems;

namespace PM.DTM.Domain.Models.Sprints;

public class Sprint : Entity
{
	public string Name { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public ICollection<WorkItem> WorkItems { get; set; } = new List<WorkItem>();
}