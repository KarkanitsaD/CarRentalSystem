using System;
using API.Models.Request.Booking;
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
        }
    }
}