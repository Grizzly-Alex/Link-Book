using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Responses;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.AliasLinkHandlers;

internal sealed class DeleteAliasLinkHandler : IRequestHandler<DeleteAliasLinkCommand, Response>
{
    private readonly IAliasLinkRepository _repository;

    public DeleteAliasLinkHandler(IAliasLinkRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(DeleteAliasLinkCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.Delete(request.Id, cancellationToken);

        return new Response(null, result, result ? $"deleted successfully" : $"object not found");
    }
}