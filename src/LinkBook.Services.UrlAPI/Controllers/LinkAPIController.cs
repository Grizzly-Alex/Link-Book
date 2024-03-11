using AutoMapper;
using LinkBook.Services.UrlAPI.Data;
using LinkBook.Services.UrlAPI.Models;
using Microsoft.AspNetCore.Mvc;
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
    public object GetAll(string userId)
    {
        try
        {
            //Get all links by user Id
            IEnumerable<Link> objList = _db.Links.Where(link => link.UserId.Equals(userId));
            return objList;
        }
        catch (Exception ex)
        {

        }
        return null;
    }

    [HttpGet("get-favorites")]
    public object GetFavorites(string userId)
    {
        try
        {
            //Get all links by user Id
            IEnumerable<Link> objList = _db.Links.Where(link => link.UserId.Equals(userId) && link.Favorite);
            return default;
        }
        catch (Exception ex)
        {

        }
        return null;
    }


    [HttpPost]
    public object Post([FromBody] LinkDto linkDto)
    {
        try
        {
            //Create new Link
            Link opj = _mapper.Map<Link>(linkDto);

            return default;
        }
        catch (Exception ex)
        {

        }
        return null;
    }

    [HttpPut]
    public object Put([FromBody] LinkDto linkDto)
    {
        try
        {
            //Update Link
            return default;
        }
        catch (Exception ex)
        {

        }
        return null;
    }

    [HttpDelete]
    public object Delete(Guid linkId, string userId)
    {
        try
        {
            //Delete Link
            return default;
        }
        catch (Exception ex)
        {

        }
        return null;
    }
}
