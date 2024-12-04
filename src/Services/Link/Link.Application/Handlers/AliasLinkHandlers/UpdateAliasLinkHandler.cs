using AutoMapper;
using Link.Application.Commands;
using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Entities.Link;
using Link.Core.Interfaces;


namespace Link.Application.Handlers.AliasLinkHandlers;

internal sealed class UpdateAliasLinkHandler : ICommandHandler<UpdateAliasLinkCommand>
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

    public async Task<Result> Handle(UpdateAliasLinkCommand request, CancellationToken cancellationToken)
    {
        if (request.CategoryId is not null)
            if (!await _query.Contains(request.CategoryId, cancellationToken))
                return Result.Failure(CategoryErrors.NotFound);

        var link = _mapper.Map<AliasLink>(request);

        if(!await _repository.Update(link, cancellationToken))
            return Result.Failure(LinkErrors.NotFound);

        return Result.Success();
    }
}