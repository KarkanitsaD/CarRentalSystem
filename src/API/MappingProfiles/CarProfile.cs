using System;
using AutoMapper;
using Business.Models;
using Business.Models.Car;
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

            CreateMap<AddCarModel, CarEntity>()
                .ForMember(dest => dest.CarBrand, act => act.MapFrom(src => src.Brand + " " + src.Model))
                .ForMember(dest => dest.FuelConsumptionPerHundredKilometers,
                    act => act.MapFrom(src => src.FuelConsumptionPerHundredKilometers))
                .ForMember(dest => dest.TransmissionType, act => act.MapFrom(src => src.TransmissionType))
                .ForMember(dest => dest.NumberOfSeats, act => act.MapFrom(src => src.NumberOfSeats))
                .ForMember(dest => dest.Color, act => act.MapFrom(src => src.Color))
                .ForMember(dest => dest.RentalPointId, act => act.MapFrom(src => src.RentalPointId))
                .ForMember(dest => dest.PricePerDay, act => act.MapFrom(src => src.PricePerDay));

            CreateMap<AddCarModel, CarPictureEntity>()
                .ForMember(dest => dest.Content, act => act.MapFrom(src => Convert.FromBase64String(src.PictureBase64Content)))
                .ForMember(dest => dest.Extension, act => act.MapFrom(src => src.PictureExtension))
                .ForMember(dest => dest.ShortName, act => act.MapFrom(src => src.PictureShortName));
        }
    }
}