using Link.Core.Entities;
using MediatR;

namespace Link.Application.Queries;


public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
