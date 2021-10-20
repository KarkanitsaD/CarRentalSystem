using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class AdditionalFacilityProfile : Profile
    {
        public AdditionalFacilityProfile()
        {
            CreateMap<AdditionalFacilityEntity, AdditionalFacilityModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                .ForMember(dest => dest.Price, act => act.MapFrom(src => src.Price))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description))
                .ReverseMap();
        }
    }
}