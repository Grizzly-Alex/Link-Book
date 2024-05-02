using AutoMapper;
using Link.Application.Queries.LinkCategoryQueries;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkCategoryHandlers;

public sealed class GetAllUserLinkByCategoryHandler : IRequestHandler<GetAllUserLinksByCategoryQuery, IList<UserLinkResponse>>
{
    private readonly IRepository<UserLink> _repository;
    private IMapper _mapper;

    public GetAllUserLinkByCategoryHandler(
        IRepository<UserLink> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<IList<UserLinkResponse>> Handle(GetAllUserLinksByCategoryQuery request, CancellationToken cancellationToken)
    {
        var userLinks = await _repository.GetAll(
            userLink => userLink.UserId.Equals(request.UserId) && userLink.CategoryId.Equals(request.CategoryId),
            token: cancellationToken);

        return _mapper.Map<IList<UserLinkResponse>>(userLinks);
    }
}
