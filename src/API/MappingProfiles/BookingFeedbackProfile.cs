using API.Models.Response.Booking;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class BookingFeedbackProfile : Profile
    {
        public BookingFeedbackProfile()
        {
            CreateMap<BookingFeedbackModel, BookingFeedbackResponse>();
        }
    }
}