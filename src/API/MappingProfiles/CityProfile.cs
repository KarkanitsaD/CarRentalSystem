using AutoMapper;
using Business.Models;
using Data.Entities;

namespace API.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityEntity, CityModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                .ForMember(dest => dest.CountryId, act => act.MapFrom(src => src.CountryId));
        }
    }
}