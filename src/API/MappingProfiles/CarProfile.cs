using AutoMapper;
using Business.Models;
using Data.Entities;

namespace API.MappingProfiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarEntity, CarModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.CarBrand, act => act.MapFrom(src => src.CarBrand))
                .ForMember(dest => dest.FuelConsumptionPerHundredKilometers, 
                    act => act.MapFrom(src => src.FuelConsumptionPerHundredKilometers))
                .ForMember(dest => dest.TransmissionType, act => act.MapFrom(src => src.TransmissionType))
                .ForMember(dest => dest.NumberOfSeats, act => act.MapFrom(src => src.NumberOfSeats))
                .ForMember(dest => dest.Color, act => act.MapFrom(src => src.Color))
                .ForMember(dest => dest.VehicleNumber, act => act.MapFrom(src => src.VehicleNumber))
                .ForMember(dest => dest.RentalPointId, act => act.MapFrom(src => src.RentalPointId))
                .ForMember(dest => dest.LastViewTime, act => act.MapFrom(src => src.LastViewTime))
                .ForMember(dest => dest.PricePerDay, act => act.MapFrom(src => src.PricePerDay))
                .ReverseMap();
        }
    }
}