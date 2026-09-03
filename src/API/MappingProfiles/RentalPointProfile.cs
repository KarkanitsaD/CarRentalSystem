using API.Models.Request.RentalPoint;
using API.Models.Response.RentalPoint;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class RentalPointProfile : Profile
    {
        public RentalPointProfile()
        {
            CreateMap<CreateRentalPointRequest, RentalPointModel>()
                .ForMember(src => src.Bookings, act => act.Ignore())
                .ForMember(src => src.Bookings, act => act.Ignore())
                .ForMember(src => src.Cars, act => act.Ignore())
                .ForMember(src => src.Country, act => act.MapFrom(dest => new CountryModel() { Title = dest.Country }))
                .ForMember(src => src.City, act => act.MapFrom(dest => new CityModel() { Title = dest.City }));

            CreateMap<UpdateRentalPointRequest, RentalPointModel>()
                .ForMember(src => src.Bookings, act => act.Ignore())
                .ForMember(src => src.Bookings, act => act.Ignore())
                .ForMember(src => src.Cars, act => act.Ignore());

            CreateMap<RentalPointModel, RentalPointResponseModel>()
                .ForMember(src => src.Country, act => act.MapFrom(dest => dest.Country.Title))
                .ForMember(src => src.City, act => act.MapFrom(dest => dest.City.Title));
        }
    }
}