﻿using Link.Application.Commands.CategoryLinkCommands;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkCategoryHandlers;

public sealed class DeleteLinkCategoryHandler : IRequestHandler<DeleteCategoryLinkCommand, bool>
{
    private readonly IRepository<CategoryLink> _repository;

    public DeleteLinkCategoryHandler(IRepository<CategoryLink> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteCategoryLinkCommand request, CancellationToken cancellationToken)
    {

        var linkCategory = await _repository.Get(category => category.Id == request.Id, token: cancellationToken);

        if (linkCategory is null)
        {
            return false;
        }

        return await _repository.Delete(linkCategory, cancellationToken);
    }
}