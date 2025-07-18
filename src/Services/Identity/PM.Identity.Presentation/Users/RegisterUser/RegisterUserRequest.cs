namespace PM.Identity.Presentation.Users.RegisterUser;

public record RegisterUserRequest(
	string Email, 
	string Password,
	string FirstName,
	string LastName);