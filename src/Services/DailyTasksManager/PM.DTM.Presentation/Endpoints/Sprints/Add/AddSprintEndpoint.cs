using MediatR;
using PM.Common.Presentation.Endpoints;
using PM.Common.Presentation.Results;
using PM.DTM.Application.Sprints.Add;

namespace PM.DTM.Presentation.Endpoints.Sprints.Add;

public class AddSprintEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("sprints",
			async (AddSprintRequest request, ISender sender) =>
			{
				var result = await sender.Send(new AddSprintCommand
				{
					Name = request.Name,
					StartDate = request.StartDate,
					EndDate = request.EndDate
				});

				return result.Match(Results.Ok, ApiResults.Problem);
			}).RequireAuthorization("UserOnly");
	}
}