using AutoMapper;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Responses;
using Link.Core.Entities.Category;
using Link.Core.Entities.Link;

namespace Link.Application.Utilities;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region AliasCategory
        CreateMap<AliasCategory, AliasCategoryResponse>().ReverseMap();
        CreateMap<AliasCategory, CreateAliasCategoryCommand>().ReverseMap();
        CreateMap<AliasCategory, UpdateAliasCategoryCommand>().ReverseMap()
            .ForMember(model => model.Name, opt => opt.MapFrom(model => model.NewName));
        #endregion

        #region AliasLink
        CreateMap<AliasLink, CreateAliasLinkCommand>().ReverseMap();
        CreateMap<AliasLink, UpdateAliasLinkCommand>().ReverseMap();
        CreateMap<AliasLink, AliasLinkResponse>().ReverseMap();
        #endregion
    }
}
