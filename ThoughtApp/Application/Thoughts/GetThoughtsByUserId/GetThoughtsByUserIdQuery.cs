using ThoughtApp.Application.Abstractions.Messaging;
using ThoughtApp.Domain.Thoughts;
// using ThoughtApp.Domain.Thoughts;
// using ThoughtApp.Domain.Users;

namespace ThoughtApp.Application.Thoughts.GetThoughtsByUserId;

public record GetThoughtsByUserIdQuery(string name) : IQuery<List<Thought?>>;