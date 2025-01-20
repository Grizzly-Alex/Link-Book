using AutoMapper;
using Link.Application.Queries;
using Link.Application.Queries.AliasLinkQueries;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Interfaces;


namespace Link.Application.Handlers.AliasLinkHandlers;

internal sealed class GetAllAliasLinkByCategoryHandler : IQueryHandler<GetAllAliasLinkByCategoryQuery, IList<AliasLinkResponse>>
{
    private readonly IAliasLinkRepository _repository;
    private IMapper _mapper;

    public GetAllAliasLinkByCategoryHandler(
        IAliasLinkRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<Result<IList<AliasLinkResponse>>> Handle(GetAllAliasLinkByCategoryQuery request, CancellationToken cancellationToken)
    {
        var fromDblist = await _repository.GetAll(
            userLink => userLink.CategoryId.Equals(request.CategoryId),
            token: cancellationToken);

        var responseList = _mapper.Map<IList<AliasLinkResponse>>(fromDblist);

        return responseList.Any()
            ? Result.Success(responseList)
            : Result.Failure<IList<AliasLinkResponse>>(CategoryErrors.NotFound);
    }
}
