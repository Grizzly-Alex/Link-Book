using Link.Application.Responses;
using MediatR;

namespace Link.Application.Queries.LinkCategoryQueries;

public record class GetAllLinkCategoriesByUserQuery(string UserId) : IRequest<IList<CategoryLinkResponse>>;
