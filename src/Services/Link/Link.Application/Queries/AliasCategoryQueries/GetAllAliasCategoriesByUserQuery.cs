using Link.Application.Responses;

namespace Link.Application.Queries.AliasCategoryQueries;

public record class GetAllAliasCategoriesByUserQuery(string UserId) : IQuery<IList<AliasCategoryResponse>>;
