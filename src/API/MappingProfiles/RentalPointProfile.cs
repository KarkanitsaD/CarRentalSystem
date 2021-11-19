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
            CreateMap<CreateRentalPointRequestModel, RentalPointModel>()
                .ForMember(src => src.Bookings, act => act.Ignore())
                .ForMember(src => src.City, act => act.Ignore())
                .ForMember(src => src.Country, act => act.Ignore())
                .ForMember(src => src.Bookings, act => act.Ignore())
                .ForMember(src => src.Cars, act => act.Ignore());

            CreateMap<RentalPointModel, RentalPointResponseModel>();
        }
    }
}