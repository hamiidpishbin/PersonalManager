namespace DTM.Domain.DailyTasks;

public sealed class DailyTask
{
	public Guid Id { get; private set; }
	public Guid SprintTaskId { get; private set; }
	public DateTime StartDate { get; private set; }
	public DateTime EndDate { get; private set; }
	public TimeSpan Duration { get; private set; }
	public string Description { get; private set; }
}