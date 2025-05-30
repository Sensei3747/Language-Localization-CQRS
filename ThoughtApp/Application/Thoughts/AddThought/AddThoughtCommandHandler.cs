using ThoughtApp.Domain.Thoughts;
using ThoughtApp.Domain.Users;
using ThoughtApp.Application.Abstractions.Messaging;
using ThoughtApp.Domain.Abstractions;

namespace ThoughtApp.Application.Thoughts.AddThought;

public class AddThoughtCommandHandler : ICommandHandler<AddThoughtCommand, string>
{
    public IThoughtRepository _thoughtRepository;
    public IUnitOfWork _unitOfWork;
    public IUserRepository _userRepository;

    public AddThoughtCommandHandler(IThoughtRepository thoughtRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _thoughtRepository = thoughtRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<string>> Handle(AddThoughtCommand request, CancellationToken token)
    {
        var user = await _userRepository.GetByName(request.name);
        if (user is null)
        {
            return Result.Failure<string>(UserErrors.NotFound);
        }
        var thought = Thought.Create(request.content, user.Id, request.type, request.language);
        await _thoughtRepository.AddAsync(thought);
        return user.Name;
    }
}