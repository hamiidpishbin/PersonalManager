using PM.Common.Domain;

namespace PM.Identity.Domain.Users;

public sealed class User : Entity
{
	public Guid Id { get; private set; }
	public string Email { get; private set; } = null!;
	public string Password { get; private set; } = null!;
	public string FirstName { get; private set; } = null!;
	public string LastName { get; private set; } = null!;

	private User()
	{
	}

	public static User Create(string email, string password, string firstName, string lastName)
	{
		var user = new User()
		{
			Id = Guid.NewGuid(),
			Email = email,
			Password = password,
			FirstName = firstName,
			LastName = lastName
		};
		
		user.RaiseDomainEvent(new UserRegisteredDomainEvent(user.Id));

		return user;
	}
}