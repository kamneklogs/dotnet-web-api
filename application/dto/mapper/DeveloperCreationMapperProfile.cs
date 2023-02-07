using AutoMapper;
using e07.domain.model;

namespace e07.application.dto.mapper;

public class DeveloperCreationMapperProfile : Profile
{
    public DeveloperCreationMapperProfile()
    {
        CreateMap<DeveloperModificationDTO, Developer>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.DeveloperType, opt => opt.MapFrom(src => DeveloperTypeExtensions.FromId(src.DeveloperTypeId)));
    }
}