using AutoMapper;
using Link.Application.Commands.CategoryLinkCommands;
using Link.Application.Responses;
using Link.Core.Entities;

namespace Link.Application.Utilities;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region LinkCategory
        CreateMap<CategoryLink, CategoryLinkResponse>().ReverseMap();
        CreateMap<CategoryLink, CreateCategoryLinkCommand>().ReverseMap();
        CreateMap<CategoryLink, UpdateCategoryLinkCommand>().ReverseMap()
            .ForMember(model => model.Name, opt => opt.MapFrom(model => model.NewName));
        #endregion

        #region AliasLink
        CreateMap<AliasLinkResponse, AliasLink>().ReverseMap()
            .ForMember(model => model.Category, opt => opt.MapFrom(model => model.Category.Name));
        #endregion
    }
}
