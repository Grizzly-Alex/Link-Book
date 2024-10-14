using Link.Application.Responses;
using MediatR;

namespace Link.Application.Queries.AliasCategoryQueries;

public record class GetAllAliasCategoriesByUserQuery(string UserId) : IRequest<Response>;
