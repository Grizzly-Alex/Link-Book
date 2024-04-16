using AutoMapper;
using Link.Application.Commands.LinkTagCommands;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkCategoryHandlers;

public sealed class CreateLinkCategoryCommandHandler : IRequestHandler<CreateLinkTagCommand, LinkCategory>
{
    private readonly IRepository<LinkCategory> _repository;
    private readonly IMapper _mapper;

    public CreateLinkCategoryCommandHandler(IRepository<LinkCategory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;           
    }

    public Task<LinkCategory> Handle(CreateLinkTagCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
