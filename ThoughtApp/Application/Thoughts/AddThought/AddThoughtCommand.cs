using ThoughtApp.Application.Abstractions.Messaging;
using ThoughtApp.Domain.Languages;
using ThoughtApp.Domain.Type;

namespace ThoughtApp.Application.Thoughts.AddThought;

public record AddThoughtCommand(string name, string content, Types type, Language language) : ICommand<string>;
