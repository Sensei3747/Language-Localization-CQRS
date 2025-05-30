using ThoughtApp.Application.Abstractions.Messaging;
using ThoughtApp.Domain.Users;
using ThoughtApp.Domain.Thoughts;
using ThoughtApp.Domain.Abstractions;

namespace ThoughtApp.Application.Thoughts.GetThoughtsByUserId;

public class GetThoughtsByUserIdQueryHandler : IQueryHandler<GetThoughtsByUserIdQuery, List<Thought?>>
{
    public IUserRepository _userRepository;
    public IThoughtRepository _thoughtRepository;

    public GetThoughtsByUserIdQueryHandler(IUserRepository userRepository, IThoughtRepository thoughtRepository)
    {
        _userRepository = userRepository;
        _thoughtRepository = thoughtRepository;
    }

    public async Task<Result<List<Thought?>>> Handle(GetThoughtsByUserIdQuery request, CancellationToken token)
    {
        var user = await _userRepository.GetByName(request.name);
        if (user is null)
        {
            return Result.Failure<List<Thought?>>(Error.NotFound("Not Found", "User not Found."));
        }
        var thought = await _thoughtRepository.GetThoughts(userId: user.Id);
        return thought;
    }
}