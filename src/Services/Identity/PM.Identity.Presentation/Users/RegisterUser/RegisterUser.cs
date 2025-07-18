using MediatR;
using PM.Common.Presentation.Endpoints;
using PM.Common.Presentation.Results;

namespace PM.Identity.Presentation.Users.RegisterUser;

public class RegisterUser : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("users/register",
			async (RegisterUserRequest request, ISender sender) =>
			{
				var command = request.ToRegisterUserCommand();

				var result = await sender.Send(command);

				return result.Match(Results.Ok, ApiResults.Problem);
			})
			.AllowAnonymous();
	}
}