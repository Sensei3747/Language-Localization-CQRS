using MediatR;
using ThoughtApp.Domain.Abstractions;

namespace ThoughtApp.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand { }
public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand { }
public interface IBaseCommand { }