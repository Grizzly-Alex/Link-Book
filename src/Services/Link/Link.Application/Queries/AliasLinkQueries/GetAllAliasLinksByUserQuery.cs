using Link.Application.Responses;
using MediatR;

namespace Link.Application.Queries.AliasLinkQueries;

public record class GetAllAliasLinksByUserQuery(string UserId) : IQuery<IList<AliasLinkResponse>>;
