using ThoughtApp.Domain.Abstractions;
using MediatR;

namespace ThoughtApp.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> {}
