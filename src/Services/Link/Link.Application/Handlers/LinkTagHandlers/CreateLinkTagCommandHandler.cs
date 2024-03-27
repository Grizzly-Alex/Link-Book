using AutoMapper;
using Link.Application.Commands.LinkTagCommands;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.LinkTagHandlers;

public sealed class CreateLinkTagCommandHandler : IRequestHandler<CreateLinkTagCommand, LinkCategory>
{
    private readonly IRepository<LinkCategory> _repository;
    private readonly IMapper _mapper;

    public CreateLinkTagCommandHandler(IRepository<LinkCategory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;           
    }

    public Task<LinkCategory> Handle(CreateLinkTagCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    //public async Task<LinkCategory> Handle(CreateLinkTagCommand request, CancellationToken cancellationToken)
    //{
    //    LinkCategory linkTag = _mapper.Map<LinkCategory>(request);
    //    await _repository.Create(linkTag, cancellationToken);
    //}
}
