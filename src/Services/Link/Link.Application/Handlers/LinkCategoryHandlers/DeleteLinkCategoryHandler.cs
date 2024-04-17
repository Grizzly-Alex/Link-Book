using Link.Application.Commands.LinkTagCommands;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkCategoryHandlers;

public sealed class DeleteLinkCategoryHandler : IRequestHandler<DeleteLinkCategoryQuery, bool>
{
    private readonly IRepository<LinkCategory> _repository;

    public DeleteLinkCategoryHandler(IRepository<LinkCategory> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteLinkCategoryQuery request, CancellationToken cancellationToken)
    {

        var linkCategory = await _repository.Get(category => category.Id == request.Id, token: cancellationToken);

        if (linkCategory is null)
        {
            return false;
        }

        return await _repository.Delete(linkCategory, cancellationToken);
    }
}