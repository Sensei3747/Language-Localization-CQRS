using ThoughtApp.Application.Users.Login;
using ThoughtApp.Application.Users.Register;
using ThoughtApp.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;

namespace ThoughtApp.API.Controllers.Users;

[Route("api/users")]
[ApiController]
[AllowAnonymous]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterUserCommand(request.name, request.password);
        var result = await _sender.Send(command);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }

    [AllowAnonymous]
    [HttpGet("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginUserQuery(request.name, request.password);
        var result = await _sender.Send(query);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }
}