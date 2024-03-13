using AutoMapper;
using LinkBook.Services.UrlAPI.Data;
using LinkBook.Services.UrlAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LinkBook.Services.UrlAPI.Controllers;

[Route("api/link")]
[ApiController]
public class LinkAPIController : ControllerBase
{
    private readonly AppDbContext _db;
    private IMapper _mapper;

    public LinkAPIController(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    [HttpGet("get-all/{userId}")]
    public async Task<IActionResult> GetAll(string userId)
    {      
        List<Link> objList = await _db.Links
            .Where(link => link.UserId.Equals(userId))
            .OrderBy(link => link.Id)
            .ToListAsync();

        return objList.Any() ? Ok(objList) : NotFound(objList);
    }

    [HttpGet("get-favorites/{userId}")]
    public async Task<IActionResult> GetFavorites(string userId)
    {
        var objList = await _db.Links
            .Where(link => link.UserId.Equals(userId) && link.Favorite)
            .OrderBy(link => link.Id)
            .ToListAsync();

        return objList.Any() ? Ok(objList) : NotFound(objList);

    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LinkDto linkDto, CancellationToken token)
    {
        Link obj = _mapper.Map<Link>(linkDto);
        await _db.Links.AddAsync(obj);
        await _db.SaveChangesAsync(token);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] LinkDto linkDto, CancellationToken token)
    {
        Link obj = _mapper.Map<Link>(linkDto);
        _db.Links.Update(obj);
        await _db.SaveChangesAsync(token);

        return Ok();
    }

    [HttpDelete("{linkId:guid}")]
    public async Task<IActionResult> Delete(Guid linkId, CancellationToken token)
    {
        Link obj = await _db.Links.FirstAsync(link => link.Id.Equals(linkId));
        _db.Remove(obj);
        await _db.SaveChangesAsync(token);

        return Ok();
    }
}
