namespace PM.Common.Presentation.Auth;

public class JwtOptionsConfig
{
	public string Authority { get; set; } = null!;
	public string Audience { get; set; } = null!;
	public bool RequireHttpsMetadata { get; set; }
	public TokenValidationParametersConfig TokenValidationParameters { get; set; }
}

public class TokenValidationParametersConfig
{
	public bool ValidateIssuer { get; set; }
	public string ValidIssuer { get; set; } = null!;
	public bool ValidateAudience { get; set; }
	public string ValidAudience { get; set; } = null!;
}