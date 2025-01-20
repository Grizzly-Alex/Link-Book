using Link.Core.Entities;
using MediatR;

namespace Link.Application.Commands;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
