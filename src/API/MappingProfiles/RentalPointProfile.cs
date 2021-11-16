using AutoMapper;
using Business.Models;
using Data.Entities;

namespace API.MappingProfiles
{
    public class RentalPointProfile : Profile
    {
        public RentalPointProfile()
        {
            CreateMap<RentalPointEntity, RentalPointModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Address))
                .ForMember(dest => dest.CityId, act => act.MapFrom(src => src.CityId))
                .ForMember(dest => dest.CountryId, act => act.MapFrom(src => src.CountryId));
        }
    }
}