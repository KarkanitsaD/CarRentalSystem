using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingEntity, BookingModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.BookingTime, act => act.MapFrom(src => src.BookingTime))
                .ForMember(dest => dest.KeyHandOverTime, act => act.MapFrom(src => src.KeyHandOverTime))
                .ForMember(dest => dest.KeyReceivingTime, act => act.MapFrom(src => src.KeyReceivingTime))
                .ForMember(dest => dest.CarId, act => act.MapFrom(src => src.CarId))
                .ForMember(dest => dest.UserId, act => act.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RentalPointId, act => act.MapFrom(src => src.RentalPointId))
                .ReverseMap();
        }
    }
}
