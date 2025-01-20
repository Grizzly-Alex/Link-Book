using Link.Core.Entities;
using MediatR;

namespace Link.Application.Queries;


public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
