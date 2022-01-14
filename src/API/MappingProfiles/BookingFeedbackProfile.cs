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
        }
    }
}