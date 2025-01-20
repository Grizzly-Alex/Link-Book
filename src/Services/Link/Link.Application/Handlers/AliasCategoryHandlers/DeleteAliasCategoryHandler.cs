using Link.Application.Commands;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Interfaces;

namespace Link.Application.Handlers.AliasCategoryHandlers;

internal sealed class DeleteAliasCategoryHandler : ICommandHandler<DeleteAliasCategoryCommand>
{
    private readonly IAliasCategoryRepository _repository;

    public DeleteAliasCategoryHandler(IAliasCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteAliasCategoryCommand request, CancellationToken cancellationToken)
    {
        var isSuccess = await _repository.Delete(request.Id, cancellationToken);

        return isSuccess 
            ? Result.Success() 
            : Result.Failure(CategoryErrors.NotFound);  
    }
}