using ThoughtApp.Application.Abstractions.Messaging;
using ThoughtApp.Domain.Thoughts;
using ThoughtApp.Domain.Type;

namespace ThoughtApp.Application.Thoughts.GetThoughtsByType;

public record GetThoughtsByTypeQuery(string name, Types type) : IQuery<List<Thought?>>;