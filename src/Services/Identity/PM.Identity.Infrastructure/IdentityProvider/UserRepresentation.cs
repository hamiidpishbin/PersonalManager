namespace PM.Identity.Infrastructure.IdentityProvider;

internal sealed record UserRepresentation(
	string Username,
	string Email,
	string FirstName,
	string LastName,
	bool EmailVerified,
	bool Enabled,
	CredentialRepresentation[] Credentials);