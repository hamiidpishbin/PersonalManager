using PM.Common.Presentation.Endpoints;

namespace PM.DTM.API.TestAPIs;

public class UserAuthTest : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("userAuthTest", () => Results.Ok("User logged in successfully."))
			.RequireAuthorization("UserOnly");
	}
}