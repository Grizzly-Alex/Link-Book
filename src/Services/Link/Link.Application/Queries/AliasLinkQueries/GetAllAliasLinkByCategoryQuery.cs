using Link.Application.Responses;
using MediatR;

namespace Link.Application.Queries.AliasLinkQueries;

public record class GetAllAliasLinkByCategoryQuery(Guid CategoryId) : IRequest<Response>;
