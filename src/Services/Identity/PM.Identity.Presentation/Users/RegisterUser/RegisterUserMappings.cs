using PM.Identity.Application.Users.RegisterUser;

namespace PM.Identity.Presentation.Users.RegisterUser;

public static class RegisterUserMappings
{
	public static RegisterUserCommand ToRegisterUserCommand(this RegisterUserRequest request)
	{
		return new RegisterUserCommand(
			request.Email,
			request.Password,
			request.FirstName,
			request.LastName);
	}
}