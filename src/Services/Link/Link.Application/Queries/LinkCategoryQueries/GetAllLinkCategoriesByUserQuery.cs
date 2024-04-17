using Link.Application.Responses;
using MediatR;

namespace Link.Application.Queries.LinkCategoryQueries
{
    public class GetAllLinkCategoriesByUserQuery(string userId) : IRequest<IList<LinkCategoryResponse>>
    {
        public string UserId { get; set; } = userId;
    }
}
