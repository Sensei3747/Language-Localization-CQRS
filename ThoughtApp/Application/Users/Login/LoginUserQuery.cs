using ThoughtApp.Application.Abstractions.Messaging;

namespace ThoughtApp.Application.Users.Login;

public record LoginUserQuery(string name, string hashPassword) : IQuery<string>;