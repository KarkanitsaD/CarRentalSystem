using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarEntity, CarModel>();

            CreateMap<CarModel, CarEntity>()
                .ForMember(src => src.RentalPoint, act => act.Ignore())
                .ForMember(src => src.Bookings, act => act.Ignore());
        }
    }
}