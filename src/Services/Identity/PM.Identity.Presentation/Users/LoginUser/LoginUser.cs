using MediatR;
using PM.Common.Presentation.Endpoints;
using PM.Common.Presentation.Results;
using PM.Identity.Application.Users.LoginUser;

namespace PM.Identity.Presentation.Users.LoginUser;

public class LoginUser : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("users/login",
			async (LoginUserRequest request, ISender sender) =>
			{
				var result = await sender.Send(new LoginUserQuery(request.Username, request.Password));

				return result.Match(Results.Ok, ApiResults.Problem);
			});
	}
}