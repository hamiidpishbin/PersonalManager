namespace PM.Identity.Infrastructure.IdentityProvider;

internal sealed record CredentialRepresentation(string Type, string Value, bool Temporary);