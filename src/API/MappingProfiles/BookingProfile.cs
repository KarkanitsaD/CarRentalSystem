using System;
using API.Models.Request.Booking;
using API.Models.Response.Booking;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<CreateBookingRequest, BookingModel>()
                .ForMember(src => src.BookingTime, act => act.MapFrom(dest => DateTime.Now));

            CreateMap<BookingModel, BookingResponse>()
                .ForMember(src => src.Country, act => act.MapFrom(dest => dest.RentalPoint.Country.Title))
                .ForMember(src => src.City, act => act.MapFrom(dest => dest.RentalPoint.City.Title))
                .ForMember(src => src.Brand, act => act.MapFrom(dest => dest.Car.Brand))
                .ForMember(src => src.Model, act => act.MapFrom(dest => dest.Car.Model));
        }
    }
}