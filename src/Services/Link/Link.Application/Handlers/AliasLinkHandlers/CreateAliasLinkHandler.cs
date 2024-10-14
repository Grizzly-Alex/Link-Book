using AutoMapper;
using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.AliasLinkHandlers;

public sealed class CreateAliasLinkHandler : IRequestHandler<CreateAliasLinkCommand, Response>
{
    private readonly IAliasLinkRepository _linkRepository;
    private readonly IAliasCategoryQuery<Guid?> _query;
    private readonly IMapper _mapper;

    public CreateAliasLinkHandler(IAliasLinkRepository linkRepository, IAliasCategoryQuery<Guid?> query, IMapper mapper)
    {
        _linkRepository = linkRepository;
        _query = query;
        _mapper = mapper;
    }


    public async Task<Response> Handle(CreateAliasLinkCommand request, CancellationToken cancellationToken)
    {
        if(request.CategoryId is not null)        
            if (!await _query.Contains(request.CategoryId, cancellationToken))
                return new Response(null, false, $"category not found");
        
        var result = await _linkRepository.Create(_mapper.Map<AliasLink>(request), cancellationToken);
        bool isSuccess = result != null;

        return new Response(result, isSuccess, isSuccess ? $"created successfully" : $"something wrong...");      
    }
}