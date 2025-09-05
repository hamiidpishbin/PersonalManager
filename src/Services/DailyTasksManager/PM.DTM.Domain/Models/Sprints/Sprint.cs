using PM.Common.Domain;
using PM.DTM.Domain.Models.WorkItems;

namespace PM.DTM.Domain.Models.Sprints;

public class Sprint : Entity
{
	public string Name { get; private set; }
	public DateTime StartDate { get; private set; }
	public DateTime EndDate { get; private set; }
	public IReadOnlyCollection<WorkItem> WorkItems => _workItems.AsReadOnly();

	private readonly List<WorkItem> _workItems = [];
	
	private Sprint()
	{
		
	}
	
	private Sprint(string name, DateTime startDate, DateTime endDate)
	{
		Id = Guid.NewGuid();
		Name = name;
		StartDate = startDate;
		EndDate = endDate;
	}

	public static Sprint Create(string name, DateTime startDate, DateTime endDate)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new DomainException("Name property cannot be null or empty.");
		}

		if (startDate > endDate)
		{
			throw new DomainException("Start date should be before the end date.");
		}

		return new Sprint(name, startDate, endDate);
	}

	public void AddWorkItem(WorkItem workItem)
	{
		_workItems.Add(workItem);
	}
	
	public void AddWorkItems(IEnumerable<WorkItem> workItems)
	{
		_workItems.AddRange(workItems);
	}

	public void RemoveWorkItem(WorkItem workItem)
	{
		_workItems.Remove(workItem);
	}

	public void ClearWorkItems()
	{
		_workItems.Clear();
	}
}