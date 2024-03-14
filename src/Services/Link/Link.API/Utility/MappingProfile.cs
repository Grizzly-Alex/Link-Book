using AutoMapper;
using LinkBook.Services.UrlAPI.Models;
namespace LinkBook.Services.UrlAPI.Utility;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Link, LinkDto>().ReverseMap();
           
    }
}
