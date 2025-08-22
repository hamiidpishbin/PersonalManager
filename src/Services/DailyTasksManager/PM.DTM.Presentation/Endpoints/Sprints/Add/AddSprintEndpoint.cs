using MediatR;
using PM.Common.Presentation.Endpoints;
using PM.DTM.Application.Sprints.Add;

namespace PM.DTM.Presentation.Endpoints.Sprints.Add;

public class AddSprintEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("sprints",
			async (AddSprintRequest request, ISender sender) =>
			{
				var result = await sender.Send(new AddSprintCommand()
				{
					Name = request.Name,
					StartDate = request.StartDate,
					EndDate = request.EndDate
				});

				return Results.Ok(result);
			}).RequireAuthorization("UserOnly");
	}
}