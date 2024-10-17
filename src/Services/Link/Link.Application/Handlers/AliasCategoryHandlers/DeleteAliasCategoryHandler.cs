using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Responses;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.AliasCategoryHandlers;

public sealed class DeleteAliasCategoryHandler : IRequestHandler<DeleteAliasCategoryCommand, Response>
{
    private readonly IAliasCategoryRepository _repository;

    public DeleteAliasCategoryHandler(IAliasCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(DeleteAliasCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.Delete(request.Id, cancellationToken);

        return new Response(null, result, result ? $"deleted successfully" : $"object not found");
    }
}