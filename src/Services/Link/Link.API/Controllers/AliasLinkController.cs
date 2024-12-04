using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Queries.AliasLinkQueries;
using Link.Application.Responses;
using Link.Core.Entities;
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
    [Route("[action]/{userId}", Name = "get-links-by-user")]
    [ProducesResponseType(typeof(IEnumerable<AliasLinkResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IEnumerable<AliasLinkResponse>>> GetLinks(string userId, CancellationToken token)
    {
        var query = new GetAllAliasLinksByUserQuery(userId);
        var result = await _mediator.Send(query, token);

        return result.IsSuccess 
            ? Ok(result.Value) 
            : NotFound(result.Error);
    }


    [HttpGet]
    [Route("[action]/{userId}", Name = "get-links-by-category")]
    [ProducesResponseType(typeof(IEnumerable<AliasLinkResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IEnumerable<AliasLinkResponse>>> GetLinksByCategory(string categoryId, CancellationToken token)
    {
        if (Guid.TryParse(categoryId, out Guid guidId)) 
        {
            var query = new GetAllAliasLinkByCategoryQuery(guidId);
            var result = await _mediator.Send(query, token);
            return result.IsSuccess
                ? Ok(result.Value) 
                : NotFound(result.Error);
        }

        return BadRequest(categoryId);
    }


    [HttpPost]
    [Route("create-link")]
    [ProducesResponseType(typeof(AliasLinkResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> CreateLink([FromBody] CreateAliasLinkCommand command, CancellationToken token)
    {
        var result = await _mediator.Send(command, token);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }


    [HttpPut]
    [Route("update-link")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> UpdateLink([FromBody] UpdateAliasLinkCommand command, CancellationToken token)
    {
        var result = await _mediator.Send(command, token);

        return result.IsSuccess
            ? Ok()
            : BadRequest(result.Error);
    }


    [HttpDelete]
    [Route("delete-link/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> DeleteLink(string id, CancellationToken token)
    {
        if (Guid.TryParse(id, out Guid guidId))
        {
            var response = await _mediator.Send(new DeleteAliasLinkCommand(guidId), token);
            return response.IsSuccess
                ? Ok()
                : NotFound(response.Error);
        }

        return BadRequest();
    }
}