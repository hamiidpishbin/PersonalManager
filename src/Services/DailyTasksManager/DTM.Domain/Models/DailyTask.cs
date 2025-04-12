using Common.Abstractions;
using DTM.Domain.Events;
using DTM.Domain.ValueObjects;

namespace DTM.Domain.Models;

public sealed class DailyTask : Entity
{
	public DailyTaskName DailyTaskName { get; set; }
	public Guid SprintTaskId { get; private set; }
	public DateTime StartDate { get; private set; }
	public DateTime EndDate { get; private set; }
	public TimeSpan Duration { get; private set; }
	public DailyTaskDescription Description { get; private set; }

	private DailyTask(
		Guid id,   
		DailyTaskName dailyTaskName,
		Guid sprintTaskId,
		DateTime startDate,
		DateTime endDate,
		TimeSpan duration,
		DailyTaskDescription description) : base(id)
	{
		DailyTaskName = dailyTaskName;
		SprintTaskId = sprintTaskId;
		StartDate = startDate;
		EndDate = endDate;
		Duration = duration;
		Description = description;
	}

	public static DailyTask Create(DailyTaskName dailyTaskName, Guid sprintTaskId, DailyTaskDescription description)
	{
		var dailyTask = new DailyTask(Guid.NewGuid(), dailyTaskName, sprintTaskId, DateTime.MinValue, DateTime.MinValue, TimeSpan.Zero, description);
		
		dailyTask.RaiseDomainEvent(new DailyTaskCreatedDomainEvent(dailyTask.Id));

		return dailyTask;
	}
}