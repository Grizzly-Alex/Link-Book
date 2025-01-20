using AutoMapper;
using Link.Application.Queries;
using Link.Application.Queries.AliasCategoryQueries;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Interfaces;

namespace Link.Application.Handlers.AliasCategoryHandlers;

internal sealed class GetAllAliasCategoriesByUserHandler : IQueryHandler<GetAllAliasCategoriesByUserQuery, IList<AliasCategoryResponse>>
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

    public async Task<Result<IList<AliasCategoryResponse>>> Handle(GetAllAliasCategoriesByUserQuery request, CancellationToken cancellationToken)
    {
        var fromDblist = await _repository.GetAll(category => category.UserId.Equals(request.UserId), token: cancellationToken);
        var responseList = _mapper.Map<IList<AliasCategoryResponse>>(fromDblist);

        return responseList.Any()
            ? Result.Success(responseList)
            : Result.Failure<IList<AliasCategoryResponse>>(CategoryErrors.NotFound);
    }
}
