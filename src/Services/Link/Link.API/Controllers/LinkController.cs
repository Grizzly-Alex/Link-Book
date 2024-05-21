using Link.Application.Commands.LinkTagCommands;
using Link.Application.Queries.LinkCategoryQueries;
using Link.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace LinkBook.Services.UrlAPI.Controllers;


public class LinkController : ApiController
{
    private readonly IMediator _mediator;

    public LinkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("[action]/{userId}", Name = "get-categories-by-user-id")]
    [ProducesResponseType(typeof(IEnumerable<LinkCategoryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IEnumerable<LinkCategoryResponse>>> GetCategories(string userId)
    {

        var query = new GetAllLinkCategoriesByUserQuery(userId);
        var result = await _mediator.Send(query);
        return Ok(result);

    }

    [HttpPost]
    [Route("create-category")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]

    public async Task<ActionResult<bool>> CreateCategory([FromBody] CreateLinkCategoryCommand categoryCommand)
    {
        var result = await _mediator.Send(categoryCommand);
        return Ok(result);
    }


    //[HttpGet]
    //[Route("all/{userId}")]
    //public async Task<IActionResult> GetAll(string userId)
    //{      
    //    List<UserLink> objList = await _db.Links
    //        .Where(link => link.UserId.Equals(userId))
    //        .OrderBy(link => link.Id)
    //        .ToListAsync();

    //    return objList.Any() ? Ok(objList) : NotFound();
    //}

    //[HttpGet]
    //[Route("favorites/{userId}")]
    //public async Task<IActionResult> GetFavorites(string userId)
    //{
    //    var objList = await _db.Links
    //        .Where(link => link.UserId.Equals(userId) && link.Favorite)
    //        .OrderBy(link => link.Id)
    //        .ToListAsync();

    //    return objList.Any() ? Ok(objList) : NotFound(objList);

    //}

    //[HttpPost]
    //[Route("create")]
    //public async Task<IActionResult> Post([FromBody] LinkDto linkDto, CancellationToken token)
    //{
    //    if (ModelState.IsValid) 
    //    {
    //        await _db.Links.AddAsync(_mapper.Map<Link>(linkDto), token);
    //        await _db.SaveChangesAsync(token);

    //        return Ok();
    //    }

    //    return BadRequest();
    //}

    //[HttpPut]
    //[Route("update")]
    //public async Task<IActionResult> Put([FromBody] LinkDto linkDto, CancellationToken token)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _db.Links.Update(_mapper.Map<Link>(linkDto));
    //        await _db.SaveChangesAsync(token);

    //        return Ok();
    //    }

    //    return BadRequest();
    //}

    //[HttpDelete]
    //[Route("delete/{linkId:guid}")]
    //public async Task<IActionResult> Delete(Guid linkId, CancellationToken token)
    //{
    //    Link obj = await _db.Links.FirstAsync(link => link.Id.Equals(linkId));
    //    _db.Remove(obj);
    //    await _db.SaveChangesAsync(token);

    //    return Ok();
    //}
}
