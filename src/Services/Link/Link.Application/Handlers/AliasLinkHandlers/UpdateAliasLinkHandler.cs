using AutoMapper;
using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.AliasLinkHandlers;

public sealed class UpdateAliasLinkHandler : IRequestHandler<UpdateAliasLinkCommand, Response>
{
    private readonly IAliasLinkRepository _repository;
    private readonly IAliasCategoryQuery<Guid?> _query;
    private readonly IMapper _mapper;

    public UpdateAliasLinkHandler(IAliasLinkRepository repository, IAliasCategoryQuery<Guid?> query, IMapper mapper)
    {
        _repository = repository;
        _query = query;
        _mapper = mapper;           
    }

    public async Task<Response> Handle(UpdateAliasLinkCommand request, CancellationToken cancellationToken)
    {
        if (request.CategoryId is not null)
            if (!await _query.Contains(request.CategoryId, cancellationToken))
                return new Response(null, false, $"category not found");

        var link = _mapper.Map<AliasLink>(request);

        if(!await _repository.Update(link, cancellationToken))
            return new Response(null, false, $"something wrong...");

        return new Response(null, true, $"updated successfully");
    }
}