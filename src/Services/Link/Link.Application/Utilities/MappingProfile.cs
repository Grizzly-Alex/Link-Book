using AutoMapper;
using Link.Application.Commands.LinkTagCommands;
using Link.Application.Responses;
using Link.Core.Entities;

namespace Link.Application.Utilities;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region LinkCategory
        CreateMap<LinkCategory, LinkCategoryResponse>().ReverseMap();
        CreateMap<LinkCategory, CreateLinkCategoryCommand>().ReverseMap();
        CreateMap<LinkCategory, UpdateLinkCategoryCommand>().ReverseMap()
            .ForMember(model => model.Name, opt => opt.MapFrom(model => model.NewName));
        #endregion

        #region UserLink
        CreateMap<UserLinkResponse, UserLink>().ReverseMap()
            .ForMember(model => model.Category, opt => opt.MapFrom(model => model.Category.Name));
        #endregion
    }
}
