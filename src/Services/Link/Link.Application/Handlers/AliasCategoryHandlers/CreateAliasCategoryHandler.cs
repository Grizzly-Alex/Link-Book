using AutoMapper;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.AliasCategoryHandlers;

public sealed class CreateAliasCategoryHandler : IRequestHandler<CreateAliasCategoryCommand, Response>
{
    private readonly IAliasCategoryRepository _repository;
    private readonly IAliasCategoryQuery<Guid?> _query;
    private readonly IMapper _mapper;

    public CreateAliasCategoryHandler(IAliasCategoryRepository repository, IAliasCategoryQuery<Guid?> query, IMapper mapper)
    {
        _repository = repository;
        _query = query;
        _mapper = mapper;           
    }


    public async Task<Response> Handle(CreateAliasCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<AliasCategory>(request);

        if (await _query.Contains(category, cancellationToken)) 
            return new Response(null, false, $"exists in the user's list");

        var result = await _repository.Create(category, cancellationToken);
        bool isSuccess = result != null;

        return new Response(result, isSuccess, isSuccess ? $"created successfully" : $"something wrong...");           
    }
}