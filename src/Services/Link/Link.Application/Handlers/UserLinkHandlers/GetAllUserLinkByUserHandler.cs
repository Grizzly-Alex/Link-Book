using AutoMapper;
using Link.Application.Queries.LinkCategoryQueries;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkCategoryHandlers;

public sealed class GetAllUserLinkByUserHandler : IRequestHandler<GetAllUserLinksByUserQuery, IList<UserLinkResponse>>
{
    private readonly IRepository<UserLink> _repository;
    private IMapper _mapper;

    public GetAllUserLinkByUserHandler(
        IRepository<UserLink> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IList<UserLinkResponse>> Handle(GetAllUserLinksByUserQuery request, CancellationToken cancellationToken)
    {
        var userLinks = await _repository.GetAll(category => category.UserId.Equals(request.UserId), token: cancellationToken);

        return _mapper.Map<IList<UserLinkResponse>>(userLinks);
    }
}
