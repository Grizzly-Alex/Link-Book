using AutoMapper;
using Link.Application.Queries.LinkCategoryQueries;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkCategoryHandlers;

public sealed class GetAllLinkCategoriesByUserHandler : IRequestHandler<GetAllLinkCategoriesByUserQuery, IList<CategoryLinkResponse>>
{
    private readonly IRepository<CategoryLink> _repository;
    private IMapper _mapper;

    public GetAllLinkCategoriesByUserHandler(
        IRepository<CategoryLink> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IList<CategoryLinkResponse>> Handle(GetAllLinkCategoriesByUserQuery request, CancellationToken cancellationToken)
    {
        var linkCategories = await _repository.GetAll(category => category.UserId.Equals(request.UserId), token: cancellationToken);

        return _mapper.Map<IList<CategoryLinkResponse>>(linkCategories);
    }
}
