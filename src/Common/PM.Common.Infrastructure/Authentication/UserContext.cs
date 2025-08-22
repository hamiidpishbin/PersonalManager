using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PM.Common.Application.Abstractions.Authentication;

namespace PM.Common.Infrastructure.Authentication;

internal sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
	public Guid UserId => httpContextAccessor
		.HttpContext?
		.User
		.GetUserId() ?? throw new UnauthorizedAccessException("User context unavailable");

	public IEnumerable<string> Roles => httpContextAccessor
		.HttpContext?
		.User
		.GetUserRoles() ?? [];
}

internal static class ClaimsPrincipalExtensions
{
	public static Guid GetUserId(this ClaimsPrincipal? principal)
	{
		var userId = principal?.FindFirstValue(ClaimTypes.NameIdentifier);
		return Guid.TryParse(userId, out var parsedUserId) 
			? parsedUserId 
			: throw new UnauthorizedAccessException("User ID unavailable");
	}

	public static IEnumerable<string> GetUserRoles(this ClaimsPrincipal? principal)
	{
		return principal?.FindAll(ClaimTypes.Role).Select(c => c.Value) ?? [];
	}
}