using ThoughtApp.Application.Abstractions.Messaging;
using ThoughtApp.Domain.Users;
using ThoughtApp.Domain.Thoughts;
using ThoughtApp.Domain.Abstractions;

namespace ThoughtApp.Application.Thoughts.GetThoughtsByLanguage;

public class GetThoughtsByLanguageQueryHandler : IQueryHandler<GetThoughtsByLanguageQuery, List<Thought?>>
{
    public IUserRepository _userRepository;
    public IThoughtRepository _thoughtRepository;

    public GetThoughtsByLanguageQueryHandler(IUserRepository userRepository, IThoughtRepository thoughtRepository)
    {
        _userRepository = userRepository;
        _thoughtRepository = thoughtRepository;
    }

    public async Task<Result<List<Thought?>>> Handle(GetThoughtsByLanguageQuery request, CancellationToken token)
    {
        var user = _userRepository.GetByName(request.name);
        if (user is null)
        {
            return Result.Failure<List<Thought?>>(Error.NotFound("Not Found", "User Not Found"));
        }
        var thought = await _thoughtRepository.GetThoughts(language: request.language);
        return thought; 
    }
}