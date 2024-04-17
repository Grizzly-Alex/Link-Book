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
        CreateMap<LinkCategoryResponse, LinkCategory>().ReverseMap();
        CreateMap<CreateLinkCategoryCommand, LinkCategory>().ReverseMap();
        CreateMap<UpdateLinkCategoryCommand, LinkCategory>().ReverseMap();
        #endregion

        #region UserLink
        CreateMap<UserLinkResponse, UserLink>().ReverseMap()
            .ForMember(model => model.TagName, opt => opt.MapFrom(model => model.Category.Name));
        #endregion
    }
}
