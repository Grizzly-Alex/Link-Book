using Link.Application.Commands.LinkTagCommands;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkCategoryHandlers;

public sealed class DeleteUserLinkHandler : IRequestHandler<DeleteLinkCategoryCommand, bool>
{
    private readonly IRepository<LinkCategory> _repository;

    public DeleteUserLinkHandler(IRepository<LinkCategory> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteLinkCategoryCommand request, CancellationToken cancellationToken)
    {

        var linkCategory = await _repository.Get(category => category.Id == request.Id, token: cancellationToken);

        if (linkCategory is null)
        {
            return false;
        }

        return await _repository.Delete(linkCategory, cancellationToken);
    }
}