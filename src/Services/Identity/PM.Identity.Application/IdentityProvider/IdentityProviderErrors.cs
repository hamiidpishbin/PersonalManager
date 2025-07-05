using PM.Common.Domain;

namespace PM.Identity.Application.IdentityProvider;

public static class IdentityProviderErrors
{
	public static readonly Error EmailIsNotUnique = Error.Conflict("Identity.EmailIsNotUnique", "The specified email is not unique");
}