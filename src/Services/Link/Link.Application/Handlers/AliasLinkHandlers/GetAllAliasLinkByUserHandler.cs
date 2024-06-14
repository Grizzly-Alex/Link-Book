using AutoMapper;
using Link.Application.Queries.AliasLinkQueries;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.AliasLinkHandlers;

public sealed class GetAllAliasLinkByUserHandler : IRequestHandler<GetAllAliasLinksByUserQuery, IList<AliasLinkResponse>>
{
    private readonly IRepository<AliasLink> _repository;
    private IMapper _mapper;

    public GetAllAliasLinkByUserHandler(
        IRepository<AliasLink> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IList<AliasLinkResponse>> Handle(GetAllAliasLinksByUserQuery request, CancellationToken cancellationToken)
    {
        var userLinks = await _repository.GetAll(category => category.UserId.Equals(request.UserId), token: cancellationToken);

        return _mapper.Map<IList<AliasLinkResponse>>(userLinks);
    }
}
