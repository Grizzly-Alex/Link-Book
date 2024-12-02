using AutoMapper;
using Link.Application.Queries.AliasLinkQueries;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.AliasLinkHandlers;

internal sealed class GetAllAliasLinkByCategoryHandler : IRequestHandler<GetAllAliasLinkByCategoryQuery, Response>
{
    private readonly IAliasLinkRepository _repository;
    private IMapper _mapper;

    public GetAllAliasLinkByCategoryHandler(
        IAliasLinkRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<Response> Handle(GetAllAliasLinkByCategoryQuery request, CancellationToken cancellationToken)
    {
        var userLinks = await _repository.GetAll(
            userLink => userLink.CategoryId.Equals(request.CategoryId),
            token: cancellationToken);

        return userLinks.Any()
            ? new Response(_mapper.Map<IList<AliasLinkResponse>>(userLinks), true, $"list received successfully")
            : new Response(_mapper.Map<IList<AliasLinkResponse>>(userLinks), false, $"list not found");
    }
}
