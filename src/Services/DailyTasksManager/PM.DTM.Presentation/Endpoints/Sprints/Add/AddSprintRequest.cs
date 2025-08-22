namespace PM.DTM.Presentation.Endpoints.Sprints.Add;

public class AddSprintRequest
{
	public string Name { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
}