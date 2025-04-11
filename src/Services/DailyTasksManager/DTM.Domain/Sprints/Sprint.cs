using DTM.Domain.Abstractions;

namespace DTM.Domain.Sprints;

public class Sprint : Entity
{
	private Sprint(
		Guid id,
		Name name,
		DateTime startDate,
		DateTime endDate) : base(id)
	{
		Name = name;
		StartDate = startDate;
		EndDate = endDate;
	}
	
	public Name Name { get; private set; }
	public DateTime StartDate { get; private set; }
	public DateTime EndDate { get; private set; }

	public static Sprint Create(
		Guid id,
		Name name,
		DateTime startDate,
		DateTime endDate)
	{
		return new Sprint(id, name, startDate, endDate);
	}
}