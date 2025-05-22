using Microsoft.AspNetCore.Routing;

namespace PM.Common.Presentation.Endpoints;

public interface IEndpoint
{
	void MapEndpoint(IEndpointRouteBuilder app);
}