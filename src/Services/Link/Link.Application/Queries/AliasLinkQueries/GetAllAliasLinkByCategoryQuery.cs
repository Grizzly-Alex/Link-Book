using Link.Application.Responses;
using MediatR;

namespace Link.Application.Queries.AliasLinkQueries;

public record class GetAllAliasLinkByCategoryQuery(string UserId, Guid CategoryId) : IRequest<IList<AliasLinkResponse>>;
