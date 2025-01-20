using AutoMapper;
using Link.Application.Commands;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Interfaces;


namespace Link.Application.Handlers.AliasCategoryHandlers;

internal sealed class CreateAliasCategoryHandler : ICommandHandler<CreateAliasCategoryCommand, AliasCategoryResponse>
{
    private readonly IAliasCategoryRepository _repository;
    private readonly IAliasCategoryQuery<Guid?> _query;
    private readonly IMapper _mapper;

    public CreateAliasCategoryHandler(IAliasCategoryRepository repository, IAliasCategoryQuery<Guid?> query, IMapper mapper)
    {
        _repository = repository;
        _query = query;
        _mapper = mapper;           
    }


    public async Task<Result<AliasCategoryResponse>> Handle(CreateAliasCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<AliasCategory>(request);

        if (await _query.Contains(category, cancellationToken))
            return Result.Failure<AliasCategoryResponse>(CategoryErrors.Conflict);

        var result = await _repository.Create(category, cancellationToken);

        var response = _mapper.Map<AliasCategoryResponse>(result);

        return Result.Create(response);
    }
}