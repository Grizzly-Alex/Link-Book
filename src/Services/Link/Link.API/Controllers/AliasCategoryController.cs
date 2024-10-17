using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Queries.AliasCategoryQueries;
using Link.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LinkBook.Services.UrlAPI.Controllers;

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
    [ProducesResponseType(typeof(IEnumerable<AliasCategoryResponse>), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetCategories(string userId, CancellationToken token)
    {
        var response = await _mediator.Send(new GetAllAliasCategoriesByUserQuery(userId), token);

        return response.IsSuccess 
            ? Ok(response) 
            : NotFound(response);
    }


    [HttpPost]
    [Route("create-category")]
    [ProducesResponseType(typeof(AliasCategoryResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> CreateCategory([FromBody] CreateAliasCategoryCommand command, CancellationToken token)
    {
        var response = await _mediator.Send(command, token);

        return response.IsSuccess 
            ? Ok(response) 
            : BadRequest(response);
    }
     

    [HttpPut]
    [Route("update-category")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> UpdateCategory([FromBody] UpdateAliasCategoryCommand command, CancellationToken token)
    {
        var response = await _mediator.Send(command, token);

        return response.IsSuccess 
            ? Ok(response) 
            : BadRequest(response); 
    }


    [HttpDelete]
    [Route("delete-category/{id}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> DeleteCategory(string id, CancellationToken token)
    {
        if (Guid.TryParse(id, out Guid guidId))
        {
            var response = await _mediator.Send(new DeleteAliasCategoryCommand(guidId), token);
            return response.IsSuccess 
                ? Ok(response) 
                : NotFound(response);
        }

        return BadRequest(id);
    }
}
