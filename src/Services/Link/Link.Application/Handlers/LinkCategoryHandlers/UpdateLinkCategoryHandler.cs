﻿using AutoMapper;
using Link.Application.Commands.CategoryLinkCommands;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkCategoryHandlers;

public sealed class UpdateLinkCategoryHandler : IRequestHandler<UpdateCategoryLinkCommand, bool>
{
    private readonly IRepository<CategoryLink> _repository;
    private readonly IMapper _mapper;

    public UpdateLinkCategoryHandler(IRepository<CategoryLink> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;           
    }

    public async Task<bool> Handle(UpdateCategoryLinkCommand request, CancellationToken cancellationToken)
    {
        var linkCategory = _mapper.Map<CategoryLink>(request);

        return await _repository.Update(linkCategory, cancellationToken);
    }
}