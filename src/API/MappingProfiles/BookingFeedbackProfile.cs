using API.Models.Request.Booking;
using API.Models.Response.Booking;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class BookingFeedbackProfile : Profile
    {
        public BookingFeedbackProfile()
        {
            CreateMap<CreateBookingFeedbackRequest, BookingFeedbackModel>();
            CreateMap<BookingFeedbackModel, BookingFeedbackResponse>();
            CreateMap<UpdateBookingFeedbackRequest, BookingFeedbackModel>()
                .ForMember(src => src.CarId, act => act.Ignore())
                .ForMember(src => src.Car, act => act.Ignore())
                .ForMember(src => src.BookingId, act => act.Ignore())
                .ForMember(src => src.Booking, act => act.Ignore())
                .ForMember(src => src.UserId, act => act.Ignore())
                .ForMember(src => src.User, act => act.Ignore());
        }
    }
}