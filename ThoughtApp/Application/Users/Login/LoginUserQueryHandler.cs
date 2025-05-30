using ThoughtApp.Application.Abstractions.Messaging;
using ThoughtApp.Domain.Users;
using ThoughtApp.Application.Abstractions.Auth;
using ThoughtApp.Domain.Abstractions;

namespace ThoughtApp.Application.Users.Login;

internal sealed class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, string>
{
    public IPasswordHasher _passwordHasher;
    public IUnitOfWork _unitOfWork;
    public IUserRepository _userRepository;

    public LoginUserQueryHandler(IPasswordHasher passwordHasher, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<string>> Handle(LoginUserQuery request, CancellationToken token)
    {
        var user = await _userRepository.GetByName(request.name);
        if (user is null)
        {
            return Result.Failure<string>(UserErrors.NotFound);
        }
        var isValidPassword = _passwordHasher.Verify(request.hashPassword, user.PasswordHash);
        if (!isValidPassword)
        {
            return Result.Failure<string>(UserErrors.InvalidCredentials);
        }
        var res = "Login Successful";
        return Result.Success<string>(res);
    }
}