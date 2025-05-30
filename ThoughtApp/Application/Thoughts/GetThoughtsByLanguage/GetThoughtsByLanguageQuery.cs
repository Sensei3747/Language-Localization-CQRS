using ThoughtApp.Application.Abstractions.Messaging;
using ThoughtApp.Domain.Languages;
using ThoughtApp.Domain.Thoughts;

namespace ThoughtApp.Application.Thoughts.GetThoughtsByLanguage;

public record GetThoughtsByLanguageQuery(string name, Language language) : IQuery<List<Thought?>>;