using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Queries.AliasCategoryQueries;
using Link.Application.Responses;
using Link.Core.Entities;
using LinkBook.Services.UrlAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Link.API.Controllers;

public class AliasCategoryController : ApiController
{
    private readonly IMediator _mediator;

    public AliasCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    
    [HttpGet]
    [Route("[action]/{userId}", Name = "get-categories-by-user-id")]
    [ProducesResponseType(typeof(IEnumerable<AliasCategoryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetCategories(string userId, CancellationToken token)
    {
        var result = await _mediator.Send(new GetAllAliasCategoriesByUserQuery(userId), token);

        return result.IsSuccess
            ? Ok(result.Value)
            : NotFound(result.Error);
    }


    [HttpPost]
    [Route("create-category")]
    [ProducesResponseType(typeof(AliasCategoryResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> CreateCategory(CreateAliasCategoryCommand command, CancellationToken token)
    {
        var result = await _mediator.Send(command, token);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    
    [HttpPut]
    [Route("update-category")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]

    public async Task<ActionResult> UpdateCategory([FromBody] UpdateAliasCategoryCommand command, CancellationToken token)
    {
        var response = await _mediator.Send(command, token);

        return response.IsSuccess
            ? Ok()
            : NotFound(response.Error);
    }

   
    [HttpDelete]
    [Route("delete-category/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> DeleteCategory(string id, CancellationToken token)
    {
        if (Guid.TryParse(id, out Guid guidId))
        {
            var result = await _mediator.Send(new DeleteAliasCategoryCommand(guidId), token);
            return result.IsSuccess
                ? Ok()
                : NotFound(result.Error);
        }

        return BadRequest();
    }
}
