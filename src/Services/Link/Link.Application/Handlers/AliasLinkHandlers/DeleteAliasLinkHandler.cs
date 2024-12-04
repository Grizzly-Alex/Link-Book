using Link.Application.Commands;
using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Responses;
using Link.Core.Entities;
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
        var result = await _repository.Delete(request.Id, cancellationToken);

        return Result.Create(result);
    }
}