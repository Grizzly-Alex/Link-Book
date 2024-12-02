using AutoMapper;
using Link.Application.Queries.AliasLinkQueries;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.AliasLinkHandlers;

internal sealed class GetAllAliasLinkByUserHandler : IRequestHandler<GetAllAliasLinksByUserQuery, Response>
{
    private readonly IAliasLinkRepository _repository;
    private IMapper _mapper;

    public GetAllAliasLinkByUserHandler(
        IAliasLinkRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllAliasLinksByUserQuery request, CancellationToken cancellationToken)
    {
        var userLinks = await _repository.GetAll(link => link.UserId.Equals(request.UserId), token: cancellationToken);

        return userLinks.Any()
            ? new Response(_mapper.Map<IList<AliasLinkResponse>>(userLinks), true, $"list received successfully")
            : new Response(_mapper.Map<IList<AliasLinkResponse>>(userLinks), false, $"list not found");
    }
}
