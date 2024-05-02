using Link.Application.Responses;
using MediatR;

namespace Link.Application.Queries.LinkCategoryQueries;

public record class GetAllUserLinksByUserQuery(string UserId) : IRequest<IList<UserLinkResponse>>;
