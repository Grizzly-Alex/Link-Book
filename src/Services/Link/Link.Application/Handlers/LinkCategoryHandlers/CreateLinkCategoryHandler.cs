using AutoMapper;
using Link.Application.Commands.LinkTagCommands;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkCategoryHandlers;

public sealed class CreateLinkCategoryHandler : IRequestHandler<CreateLinkCategoryCommand, bool>
{
    private readonly IRepository<LinkCategory> _repository;
    private readonly IMapper _mapper;

    public CreateLinkCategoryHandler(IRepository<LinkCategory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;           
    }

    public Task<bool> Handle(CreateLinkCategoryCommand request, CancellationToken cancellationToken)
    {
        var linkCategory = _mapper.Map<LinkCategory>(request);

        return _repository.Create(linkCategory, cancellationToken);
    }
}
