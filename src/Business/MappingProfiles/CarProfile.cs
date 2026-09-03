using AutoMapper;
using Business.Models;
using Business.Query.Car;
using Data.Entities;
using Data.Query.FiltrationModels;

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

            CreateMap<CarQueryModel, CarFiltrationModel>();
        }
    }
}