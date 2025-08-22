using PM.Common.Application.Messaging;

namespace PM.DTM.Application.Sprints.Add;

public class AddSprintCommand : ICommand
{
	public string Name { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
}