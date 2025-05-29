using Microsoft.AspNetCore.Identity;
using MediatR;
using ThoughtApp.Domain.Abstractions;

namespace ThoughtApp.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse> {}

