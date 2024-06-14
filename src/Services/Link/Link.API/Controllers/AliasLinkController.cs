using Link.Application.Commands.CategoryLinkCommands;
using Link.Application.Handlers.AliasLinkHandlers;
using Link.Application.Queries.AliasLinkQueries;
using Link.Application.Queries.LinkCategoryQueries;
using Link.Application.Responses;
using LinkBook.Services.UrlAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Link.API.Controllers;

public class AliasLinkController : ApiController
{
    private readonly IMediator _mediator;

    public AliasLinkController(IMediator mediator)
    {
        _mediator = mediator;            
    }

    [HttpGet]
    [Route("[action]/{userId}", Name = "get-links-by-user-id")]
    [ProducesResponseType(typeof(IEnumerable<AliasLinkResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(IEnumerable<AliasLinkResponse>), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IEnumerable<AliasLinkResponse>>> GetLinks(string userId, CancellationToken token)
    {
        var query = new GetAllAliasLinksByUserQuery(userId);
        var result = await _mediator.Send(query, token);

        return result.Any() ? Ok(result) : NotFound(result);
    }


    [HttpGet]
    [Route("[action]/{userId}", Name = "get-links-by-category-id")]
    [ProducesResponseType(typeof(IEnumerable<AliasLinkResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(IEnumerable<AliasLinkResponse>), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IEnumerable<AliasLinkResponse>>> GetLinksByCategory(string userId, string categoryId, CancellationToken token)
    {
        if (Guid.TryParse(categoryId, out Guid guidId)) 
        {
            var query = new GetAllAliasLinkByCategoryQuery(userId, guidId);
            var result = await _mediator.Send(query, token);
            return result.Any() ? Ok(result) : NotFound(result);
        }

        return BadRequest(categoryId);
    }

    //[HttpPost]
    //[Route("create-category")]
    //[ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //public async Task<ActionResult<bool>> CreateCategory([FromBody] CreateCategoryLinkCommand createCommand, CancellationToken token)
    //{
    //    var result = await _mediator.Send(createCommand, token);

    //    return result ? Ok(result) : BadRequest(result);
    //}
}