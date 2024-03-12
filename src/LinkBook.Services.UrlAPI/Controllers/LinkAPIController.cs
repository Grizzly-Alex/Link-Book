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


    [HttpGet("get-all")]
    public async Task<object> GetAll(string userId)
    {
        try
        {
            //Get all links by user Id
            List<Link> objList = await _db.Links
                .Where(link => link.UserId.Equals(userId))
                .OrderBy(link => link.Id)
                .ToListAsync();

            return objList;
        }
        catch (Exception ex)
        {

        }
        return null;
    }

    [HttpGet("get-favorites")]
    public async Task<object> GetFavorites(string userId)
    {
        try
        {
            //Get all links by user Id
            List <Link> objList = await _db.Links
                .Where(link => link.UserId.Equals(userId) && link.Favorite)
                .OrderBy(link => link.Id)
                .ToListAsync();

            return objList;
        }
        catch (Exception ex)
        {

        }
        return null;
    }


    [HttpPost]
    public async Task<object> Post([FromBody] LinkDto linkDto)
    {
        try
        {
            //Create new Link
            Link obj = _mapper.Map<Link>(linkDto);
            await _db.Links.AddAsync(obj);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

        }
        return false;
    }

    [HttpPut]
    public async Task<object> Put([FromBody] LinkDto linkDto)
    {
        try
        {
            //Update Link
            Link obj = _mapper.Map<Link>(linkDto);
            await _db.Links.AddAsync(obj);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

        }
        return null;
    }

    [HttpDelete]
    public async Task<object> Delete(Guid linkId)
    {
        try
        {
            //Delete Link
            Link obj = await _db.Links.FirstAsync(link => link.Id.Equals(linkId));
            _db.Remove(obj);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

        }
        return null;
    }
}
