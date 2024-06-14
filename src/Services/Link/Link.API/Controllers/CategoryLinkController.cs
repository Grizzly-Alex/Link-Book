using Link.Application.Commands.CategoryLinkCommands;
using Link.Application.Queries.LinkCategoryQueries;
using Link.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace LinkBook.Services.UrlAPI.Controllers;


public class CategoryLinkController : ApiController
{
    private readonly IMediator _mediator;

    public CategoryLinkController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("[action]/{userId}", Name = "get-categories-by-user-id")]
    [ProducesResponseType(typeof(IEnumerable<CategoryLinkResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(IEnumerable<CategoryLinkResponse>), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IEnumerable<CategoryLinkResponse>>> GetCategories(string userId, CancellationToken token)
    {
        var query = new GetAllLinkCategoriesByUserQuery(userId);
        var result = await _mediator.Send(query, token);

        return result.Any() ? Ok(result) : NotFound(result);
    }


    [HttpPost]
    [Route("create-category")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<bool>> CreateCategory([FromBody] CreateCategoryLinkCommand createCommand, CancellationToken token)
    {
        var result = await _mediator.Send(createCommand, token);

        return result ? Ok(result) : BadRequest(result);
    }


    [HttpPut]
    [Route("update-category")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<bool>> UpdateCategory([FromBody] UpdateCategoryLinkCommand updateCommand, CancellationToken token)
    {
        var result = await _mediator.Send(updateCommand, token);

        return result ? Ok(result) : BadRequest(result);
    }


    [HttpDelete]
    [Route("delete-category/{id}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<bool>> DeleteCategory(string id, CancellationToken token)
    {
        if (Guid.TryParse(id, out Guid guidId))
        {
            var result = await _mediator.Send(new DeleteCategoryLinkCommand(guidId), token);
            return result ? Ok(result) : NotFound(id);
        }

        return BadRequest(id);
    }
}
