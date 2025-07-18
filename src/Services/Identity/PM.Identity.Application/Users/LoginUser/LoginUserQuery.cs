using PM.Common.Application.Messaging;

namespace PM.Identity.Application.Users.LoginUser;

public record LoginUserQuery(string Username, string Password) : IQuery<UserToken>;