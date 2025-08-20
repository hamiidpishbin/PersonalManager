using PM.Common.Presentation.Endpoints;

namespace PM.DTM.Presentation.TestAPIs;

public class NoAuthTest : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("NoAuthTest", () => Results.Ok("Successful"));
	}
}