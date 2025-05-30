using ThoughtApp.Domain.Languages;
using ThoughtApp.Domain.Thoughts;
using ThoughtApp.Domain.Type;

namespace ThoughtApp.Api.Controllers.Thoughts;

public record CreateThoughtRequest(string name, string content, Types type, Language language);