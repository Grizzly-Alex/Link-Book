using AutoMapper;
using Link.Application.Commands.LinkTagCommands;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkTagHandlers;

public sealed class CreateLinkTagCommandHandler : IRequestHandler<CreateLinkTagCommand, LinkTag>
{
    private readonly IRepository<LinkTag> _repository;
    private readonly IMapper _mapper;

    public CreateLinkTagCommandHandler(IRepository<LinkTag> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;           
    }

    public async Task<LinkTag> Handle(CreateLinkTagCommand request, CancellationToken cancellationToken)
    {
        LinkTag linkTag = _mapper.Map<LinkTag>(request);
        await _repository.Create(linkTag, cancellationToken);
    }
}
