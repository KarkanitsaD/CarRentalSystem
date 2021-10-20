using AutoMapper;
using Business.Models;
using Data.Models;

namespace Business.MappingProfiles
{
    public class RentalPointProfile : Profile
    {
        public RentalPointProfile()
        {
            CreateMap<RentalPointEntity, RentalPointModel>()
                .ForMember(dest => dest.Country, act => act.MapFrom(src => src.Location.Country))
                .ForMember(dest => dest.City, act => act.MapFrom(src => src.Location.City))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Location.Address))
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title));

            CreateMap<RentalPointModel, RentalPointEntity>()
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                .ForMember(dest => dest.Location, act => act.MapFrom(src => new LocationEntity()
                {
                    Country = src.Country,
                    City = src.City,
                    Address = src.Address
                }));
        }
    }
}
