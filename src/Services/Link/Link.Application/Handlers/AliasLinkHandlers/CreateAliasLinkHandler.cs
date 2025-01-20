using AutoMapper;
using Link.Application.Commands;
using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Entities.Link;
using Link.Core.Interfaces;


namespace Link.Application.Handlers.AliasLinkHandlers;

internal sealed class CreateAliasLinkHandler : ICommandHandler<CreateAliasLinkCommand, AliasLinkResponse>
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


    public async Task<Result<AliasLinkResponse>> Handle(CreateAliasLinkCommand request, CancellationToken cancellationToken)
    {
        if(request.CategoryId is not null)        
            if (!await _query.Contains(request.CategoryId, cancellationToken))
                return Result.Failure<AliasLinkResponse>(CategoryErrors.NotFound);

        var aliasLink = _mapper.Map<AliasLink>(request);

        var result = await _linkRepository.Create(aliasLink, cancellationToken);

        var response = _mapper.Map<AliasLinkResponse>(result);

        return Result.Create(response);      
    }
}