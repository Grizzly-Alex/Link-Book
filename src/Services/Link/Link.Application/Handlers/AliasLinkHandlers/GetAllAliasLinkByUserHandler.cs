using AutoMapper;
using Link.Application.Queries;
using Link.Application.Queries.AliasLinkQueries;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Entities.Link;
using Link.Core.Interfaces;

namespace Link.Application.Handlers.AliasLinkHandlers;

internal sealed class GetAllAliasLinkByUserHandler : IQueryHandler<GetAllAliasLinksByUserQuery, IList<AliasLinkResponse>>
{
    private readonly IAliasLinkRepository _repository;
    private IMapper _mapper;

    public GetAllAliasLinkByUserHandler(
        IAliasLinkRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<IList<AliasLinkResponse>>> Handle(GetAllAliasLinksByUserQuery request, CancellationToken cancellationToken)
    {
        var fromDblist = await _repository.GetAll(link => link.UserId.Equals(request.UserId), token: cancellationToken);
        var responseList = _mapper.Map<IList<AliasLinkResponse>>(fromDblist);

        return responseList.Any()
            ? Result.Success(responseList)
            : Result.Failure<IList<AliasLinkResponse>>(LinkErrors.NotFound);
    }
}
