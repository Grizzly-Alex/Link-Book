using AutoMapper;
using LinkBook.Services.UrlAPI.Models;
namespace LinkBook.Services.UrlAPI.Utility;

public sealed class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        return new MapperConfiguration(config =>
        {
            config.CreateMap<LinkDto, Link>().ReverseMap();
        });
    }
}
