using PM.Common.Presentation.Endpoints;

namespace PM.DTM.API.TestAPIs;

public class AdminAuthTest : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("AdminAuthTest", () => Results.Ok("Admin logged in successfully"))
			.RequireAuthorization("AdminOnly");
	}
}