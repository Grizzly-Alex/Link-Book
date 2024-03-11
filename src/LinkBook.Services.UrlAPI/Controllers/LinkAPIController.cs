using LinkBook.Services.UrlAPI.Data;
using LinkBook.Services.UrlAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkBook.Services.UrlAPI.Controllers;

[Route("api/link")]
[ApiController]
public class LinkAPIController : ControllerBase
{
    private readonly AppDbContext _db;

    public LinkAPIController(AppDbContext db)
    {
        _db = db;         
    }


    [HttpGet("get_links")]
    public object Get(string userId)
    {
        try
        {
            IEnumerable<Link> objList = _db.Links.Where(link => link.UserId.Equals(userId));
            return objList;
        }
        catch (Exception ex)
        {

        }
        return null;

    }
}
