using AutoMapper;
using Link.Application.Commands;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Interfaces;


namespace Link.Application.Handlers.AliasCategoryHandlers;

internal sealed class UpdateAliasCategoryHandler : ICommandHandler<UpdateAliasCategoryCommand>
{
    private readonly IAliasCategoryRepository _repository;
    private readonly IMapper _mapper;

    public UpdateAliasCategoryHandler(IAliasCategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;           
    }

    public async Task<Result> Handle(UpdateAliasCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<AliasCategory>(request);

        if(!await _repository.Update(category, cancellationToken))
            return Result.Failure(CategoryErrors.NotFound);

        return Result.Success();
    }
}