namespace DTM.Domain.SprintTasks;

public sealed class SprintTask
{
	public Guid Id { get; private set; }
	public Guid SprintId { get; private set; }
	public Name Name { get; private set; }
	public Priority Priority { get; private set; }
	public Status Status { get; private set; }
}