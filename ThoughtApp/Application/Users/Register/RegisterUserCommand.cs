using ThoughtApp.Application.Abstractions.Messaging;

namespace ThoughtApp.Application.Users.Register;

public record RegisterUserCommand(string name, string password) : ICommand<string>;