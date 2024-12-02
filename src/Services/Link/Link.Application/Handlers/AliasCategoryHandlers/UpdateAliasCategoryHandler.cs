using AutoMapper;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.AliasCategoryHandlers;

internal sealed class UpdateAliasCategoryHandler : IRequestHandler<UpdateAliasCategoryCommand, Response>
{
    private readonly IAliasCategoryRepository _repository;
    private readonly IMapper _mapper;

    public UpdateAliasCategoryHandler(IAliasCategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;           
    }

    public async Task<Response> Handle(UpdateAliasCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<AliasCategory>(request);

        if(!await _repository.Update(category, cancellationToken))
            return new Response(null, false, $"object not found...");

        return new Response(null, true, $"updated successfully");
    }
}