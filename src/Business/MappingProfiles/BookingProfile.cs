using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingEntity, BookingModel>();

            CreateMap<BookingModel, BookingEntity>()
                .ForMember(src => src.Car, act => act.Ignore())
                .ForMember(src => src.User, act => act.Ignore())
                .ForMember(src => src.RentalPoint, act => act.Ignore());
        }
    }
}