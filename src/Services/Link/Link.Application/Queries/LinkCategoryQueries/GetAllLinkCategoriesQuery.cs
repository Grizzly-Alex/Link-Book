using Link.Application.Responses;
using MediatR;

namespace Link.Application.Queries.LinkCategoryQueries
{
    public class GetAllLinkCategoriesQuery : IRequest<IList<LinkCategoryResponse>>
    {
    }
}
