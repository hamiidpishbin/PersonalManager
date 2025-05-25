using PM.Common.Application.Messaging;

namespace PM.Identity.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
	string Email, 
	string Password,
	string FirstName,
	string LastName) : ICommand<Guid>;