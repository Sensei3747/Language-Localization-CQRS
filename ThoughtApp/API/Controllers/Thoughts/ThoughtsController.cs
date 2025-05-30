using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThoughtApp.Api.Controllers.Thoughts;
using ThoughtApp.Application.Thoughts.AddThought;
using ThoughtApp.Application.Thoughts.GetThoughtsByLanguage;
using ThoughtApp.Application.Thoughts.GetThoughtsByType;
using ThoughtApp.Application.Thoughts.GetThoughtsByUserId;
using ThoughtApp.Domain.Languages;
using ThoughtApp.Domain.Type;
using ThoughtApp.Extensions;

namespace ThoughtApp.API.Controllers.Thoughts;

[Route("api/thoughts")]
[ApiController]
[AllowAnonymous]
public class ThoughtsController : ControllerBase
{
    private readonly ISender _sender;

    public ThoughtsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("new")]
    public async Task<IActionResult> CreateThought(CreateThoughtRequest request)
    {
        var command = new AddThoughtCommand(request.name, request.content, request.type, request.language);
        var result = await _sender.Send(command);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }

    [HttpPost("get/thoughtuser")]
    public async Task<IActionResult> GetThoughtUser(string name)
    {
        var query = new GetThoughtsByUserIdQuery(name);
        var result = await _sender.Send(query);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }

    [HttpPost("get/thoughtType")]
    public async Task<IActionResult> GetThoughtType(string name, Types type)
    {
        var query = new GetThoughtsByTypeQuery(name, type);
        var result = await _sender.Send(query);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }

    [HttpPost("get/thoughtLanguage")]
    public async Task<IActionResult> GetThoughtLanguage(string name, Language language)
    {
        var query = new GetThoughtsByLanguageQuery(name, language);
        var result = await _sender.Send(query);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }
}