using Link.Application.Responses;
using MediatR;

namespace Link.Application.Queries.LinkCategoryQueries;

public record class GetAllUserLinksByCategoryQuery(string UserId, Guid CategoryId) : IRequest<IList<UserLinkResponse>>;
