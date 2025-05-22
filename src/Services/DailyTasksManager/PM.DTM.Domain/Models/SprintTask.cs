using PM.Common.Domain;
using PM.DTM.Domain.Enums;
using PM.DTM.Domain.Events;
using PM.DTM.Domain.ValueObjects;

namespace PM.DTM.Domain.Models;

public sealed class SprintTask : Entity
{
	public Guid SprintId { get; private set; }
	public SprintTaskName SprintTaskName { get; private set; }
	public Priority Priority { get; private set; }
	public Status Status { get; private set; }

	private SprintTask(
		Guid id,
		Guid sprintId,
		SprintTaskName sprintTaskName,
		Priority priority,
		Status status) : base(id)
	{
		SprintId = sprintId;
		SprintTaskName = sprintTaskName;
		Priority = priority;
		Status = status;
	}

	public static SprintTask Create(Guid sprintId, SprintTaskName sprintTaskName, Priority priority)
	{
		var sprintTask = new SprintTask(
			Guid.NewGuid(),
			sprintId,
			sprintTaskName,
			priority,
			Status.ToDo);
		
		sprintTask.RaiseDomainEvent(new SprintTaskCreatedEvent(sprintTask.Id));

		return sprintTask;
	}
}