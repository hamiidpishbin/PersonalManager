using PM.Common.Domain;
using PM.DTM.Domain.Events;
using PM.DTM.Domain.ValueObjects;

namespace PM.DTM.Domain.Models;

public class Sprint : Entity
{
	// public SprintName SprintName { get; private set; }
	// public DateTime StartDate { get; private set; }
	// public DateTime EndDate { get; private set; }
	//
	// private Sprint(
	// 	Guid id,
	// 	SprintName sprintName,
	// 	DateTime startDate,
	// 	DateTime endDate) : base(id)
	// {
	// 	SprintName = sprintName;
	// 	StartDate = startDate;
	// 	EndDate = endDate;
	// }
	//
	// public static Sprint Create(
	// 	SprintName sprintName,
	// 	DateTime startDate,
	// 	DateTime endDate)
	// {
	// 	var sprint = new Sprint(Guid.NewGuid(), sprintName, startDate, endDate);
	// 	
	// 	sprint.RaiseDomainEvent(new SprintCreatedDomainEvent(sprint.Id));
	// 	
	// 	return sprint;
	// }
}