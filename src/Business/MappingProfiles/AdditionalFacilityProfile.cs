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
                .ReverseMap();

            CreateMap<AdditionalFacilityBookingEntity, AdditionalFacilityModel>()
                .ForMember(src => src.Id, act => act.MapFrom(dest => dest.AdditionalFacility.Id))
                .ForMember(src => src.Price, act => act.MapFrom(dest => dest.AdditionalFacility.Price))
                .ForMember(src => src.Title, act => act.MapFrom(dest => dest.AdditionalFacility.Title))
                .ForMember(src => src.RentalPointId, act => act.MapFrom(dest => dest.AdditionalFacility.RentalPointId));
        }
    }
}