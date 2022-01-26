using AutoMapper;
using Business.Models;
using Business.Query.Booking;
using Data.Entities;
using Data.Query.FiltrationModels;

namespace Business.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingEntity, BookingModel>();

            CreateMap<BookingModel, BookingEntity>()
                .ForMember(src => src.AdditionalFacilityBookings, act => act.Ignore())
                .ForMember(src => src.Car, act => act.Ignore())
                .ForMember(src => src.User, act => act.Ignore())
                .ForMember(src => src.RentalPoint, act => act.Ignore());

            CreateMap<BookingQueryModel, BookingFiltrationModel>();
        }
    }
}