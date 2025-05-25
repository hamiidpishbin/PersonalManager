using FluentValidation;

namespace PM.Identity.Application.Users.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
	public RegisterUserCommandValidator()
	{
		RuleFor(c => c.Email).EmailAddress().WithMessage("Email address is not valid.");
		
		RuleFor(c => c.Password)
			.NotEmpty()
			.MinimumLength(6)
			.Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$")
			.WithMessage("Password must be at least 6 characters and contain at least one uppercase letter, one lowercase letter, one number, and one special character");
		
		RuleFor(c => c.FirstName).NotEmpty().WithMessage("First name cannot be empty");
		RuleFor(c => c.LastName).NotEmpty().WithMessage("Last name cannot be empty");
	}
}