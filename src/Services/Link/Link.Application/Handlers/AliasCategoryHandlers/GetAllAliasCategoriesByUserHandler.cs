using AutoMapper;
using Link.Application.Queries.AliasCategoryQueries;
using Link.Application.Responses;
using Link.Core.Interfaces;
using MediatR;

namespace Link.Application.Handlers.AliasCategoryHandlers;

public sealed class GetAllAliasCategoriesByUserHandler : IRequestHandler<GetAllAliasCategoriesByUserQuery, Response>
{
    private readonly IAliasCategoryRepository _repository;
    private IMapper _mapper;

    public GetAllAliasCategoriesByUserHandler(
        IAliasCategoryRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllAliasCategoriesByUserQuery request, CancellationToken cancellationToken)
    {
        var linkCategories = await _repository.GetAll(category => category.UserId.Equals(request.UserId), token: cancellationToken);

        return linkCategories.Any()
            ? new Response(_mapper.Map<IList<AliasCategoryResponse>>(linkCategories), true, $"list received successfully")
            : new Response(_mapper.Map<IList<AliasCategoryResponse>>(linkCategories), false, $"list not found");
    }
}
