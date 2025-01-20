using Link.Application.Responses;

namespace Link.Application.Queries.AliasLinkQueries;

public record class GetAllAliasLinkByCategoryQuery(Guid CategoryId) : IQuery<IList<AliasLinkResponse>>;
