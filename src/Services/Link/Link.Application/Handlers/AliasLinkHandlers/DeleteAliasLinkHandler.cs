using Link.Application.Commands;
using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Entities.Link;
using Link.Core.Interfaces;


namespace Link.Application.Handlers.AliasLinkHandlers;

internal sealed class DeleteAliasLinkHandler : ICommandHandler<DeleteAliasLinkCommand>
{
    private readonly IAliasLinkRepository _repository;

    public DeleteAliasLinkHandler(IAliasLinkRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteAliasLinkCommand request, CancellationToken cancellationToken)
    {
        var isSuccess = await _repository.Delete(request.Id, cancellationToken);

        return isSuccess
            ? Result.Success()
            : Result.Failure(LinkErrors.NotFound);
    }
}