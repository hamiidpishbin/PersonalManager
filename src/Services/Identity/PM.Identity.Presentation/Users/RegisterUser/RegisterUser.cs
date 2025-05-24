using PM.Common.Presentation.Endpoints;

namespace PM.Identity.Presentation.Users.RegisterUser;

public class RegisterUser : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("users/register",
			() =>
			{
				return Results.Ok("Registered OK.");
			})
			.AllowAnonymous();
	}
}