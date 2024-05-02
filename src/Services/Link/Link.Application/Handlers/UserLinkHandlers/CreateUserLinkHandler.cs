using AutoMapper;
using Link.Application.Commands.LinkTagCommands;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkCategoryHandlers;

public sealed class CreateUserLinkHandler : IRequestHandler<CreateLinkCategoryCommand, bool>
{
    private readonly IRepository<LinkCategory> _repository;
    private readonly IMapper _mapper;

    public CreateUserLinkHandler(IRepository<LinkCategory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;           
    }

    public async Task<bool> Handle(CreateLinkCategoryCommand request, CancellationToken cancellationToken)
    {
        var linkCategory = _mapper.Map<LinkCategory>(request);

        if (linkCategory is null) 
        {
            return false;
        }

        return await _repository.Create(linkCategory, cancellationToken);
    }
}