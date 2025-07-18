using PM.Identity.Domain.Users;
using PM.Identity.Infrastructure.Data;

namespace PM.Identity.Infrastructure.Users;

public class UserRepository(UsersDbContext context) : IUserRepository
{
	public void Insert(User user)
	{
		context.Users.Add(user);
	}
}