using AutoMapper;
using Link.Core.Entities;
using Link.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LinkBook.Services.UrlAPI.Controllers;


public class LinkController : ApiController
{
    private readonly AppDbContext _db;
    private IMapper _mapper;


    public LinkController(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
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
